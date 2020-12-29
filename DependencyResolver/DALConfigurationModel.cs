using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace DependencyResolverConfig
{
    public sealed class BLLConfigurationModel : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
            Bind<IIngredientService>().To<IngredientService>();
            Bind<ITableService>().To<TableService>();
            Bind<IDishService>().To<DishService>();
        }
    }
}
