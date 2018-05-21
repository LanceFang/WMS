using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Zero.Configuration;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.SignalR;
using BM.WMS.Api;
using Hangfire;
using BM.WMS.Web.Areas.SystemInfo.Startup;
using BM.WMS.Web.Bundling;
using Castle.MicroKernel.Registration;
using Microsoft.Owin.Security;
using System.Web;
using Abp.IO;
using System;
using Abp.Runtime.Caching.Redis;

namespace BM.WMS.Web
{
    [DependsOn(
        typeof(WMSDataModule),
        typeof(WMSApplicationModule),
        typeof(WMSWebApiModule),
        typeof(AbpWebSignalRModule),
        //typeof(AbpHangfireModule), - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
        //typeof(AbpRedisCacheModule),//使用Redis缓存服务，需要依赖Redis缓存模块
        typeof(AbpWebMvcModule))]
    public class WMSWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            //Configuration.Navigation.Providers.Add<WMSNavigationProvider>();
            Configuration.Navigation.Providers.Add<SystemInfoNavigationProvider>();

            //Configuration.Caching.UseRedis();//使用redis进行缓存，如果没有安装Redis 缓存组件则会报错
            Configuration.Caching.ConfigureAll(cache => { cache.DefaultSlidingExpireTime = TimeSpan.FromHours(1.5); });

            //Configure Hangfire - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
            //Configuration.BackgroundJobs.UseHangfire(configuration =>
            //{
            //    configuration.GlobalConfiguration.UseSqlServerStorage("Default");
            //});

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
                 Component
                     .For<IAuthenticationManager>()
                     .UsingFactoryMethod(() => HttpContext.Current.GetOwinContext().Authentication)
                     .LifestyleTransient()
                 );
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.IgnoreList.Clear();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SystemBundelConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void PostInitialize()
        {
            var server = HttpContext.Current.Server;
            var appFolders = IocManager.Resolve<AppFolders>();

            appFolders.SampleProfileImagesFolder = server.MapPath("~/Common/Images/SampleProfilePics");
            appFolders.TempFileDownloadFolder = server.MapPath("~/Temp/Downloads");
            appFolders.WebLogsFolder = server.MapPath("~/App_Data/Logs");
            try { DirectoryHelper.CreateIfNotExists(appFolders.TempFileDownloadFolder); } catch { }
        }
    }
}
