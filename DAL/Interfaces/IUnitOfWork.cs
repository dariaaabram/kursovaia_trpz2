using System;
using DAL.Interfaces.RepositoryInterfaces;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         IIngredientRepository Ingredients { get; }
        IDishRepository Dishes { get; }
        IOrderRepository Orders { get; }
        ITableRepository Tables { get; }
        void Save();
    }
}