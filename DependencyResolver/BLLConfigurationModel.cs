using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Web.Common;
using DAL.Entity_Framework;
using System.Data.Entity;
using Ninject.Modules;
using DAL.Interfaces.RepositoryInterfaces;

namespace DependencyResolver
{
    public sealed class DALConfigurationModel : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            Bind<DbContext>().To<Context>().InSingletonScope();
            Bind<IOrderRepository>().To<OrderRepository>().InSingletonScope();
            Bind<IDishRepository>().To<DishRepository>().InSingletonScope();
            Bind<IIngredientRepository>().To<IngredientRepository>().InSingletonScope();
            Bind<ITableRepository>().To<TableRepository>().InSingletonScope();
        }
    }
}