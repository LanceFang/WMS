using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using BM.WMS.DataExporting.Excel.EpPlus;
using BM.WMS.Dto;
using BM.WMS.MaterielsClass.Dtos;

namespace BM.WMS.MaterielsClass
{
    /// <summary>
    /// 物料分类的导出EXCEL功能的实现
    /// </summary>
    public class MaterielsClassesListExcelExporter : EpPlusExcelExporterBase, IMaterielsClassesListExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;
        /// <summary>
        /// 构造方法
        /// </summary>
        public MaterielsClassesListExcelExporter(ITimeZoneConverter timeZoneConverter, IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        /// <summary>
        /// 导出物料分类到EXCEL文件
        /// <param name="materielsClassesListDtos">导出信息的DTO</param>
        /// </summary>
        public FileDto ExportMaterielsClassesToFile(List<MaterielsClassesListDto> materielsClassesListDtos)
        {
            var file = CreateExcelPackage("materielsClassesList.xlsx", excelPackage =>
            {
                var sheet = excelPackage.Workbook.Worksheets.Add(L("MaterielsClasses"));
                sheet.OutLineApplyStyle = true;
                AddHeader(sheet, L("IsEnable"), L("CreationTime"));
                AddObjects(sheet, 2, materielsClassesListDtos,
                _ => _.IsEnable,
                _ => _timeZoneConverter.Convert(_.CreationTime, _abpSession.TenantId, _abpSession.GetUserId())
                );
                //写个时间转换的吧
                //var creationTimeColumn = sheet.Column(10);
                //creationTimeColumn.Style.Numberformat.Format = "yyyy-mm-dd";
                for (var i = 1; i <= 2; i++)
                {
                    sheet.Column(i).AutoFit();
                }
            });
            return file;
        }
    }
}
