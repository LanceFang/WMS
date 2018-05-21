using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace BM.WMS.EntityFramework.Repositories
{
    public abstract class WMSRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<WMSDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected WMSRepositoryBase(IDbContextProvider<WMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class WMSRepositoryBase<TEntity> : WMSRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected WMSRepositoryBase(IDbContextProvider<WMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
