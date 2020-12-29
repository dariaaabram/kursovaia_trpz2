using DAL.Interfaces;
using System;
using System.Data.Entity;
using DAL.Interfaces.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public IIngredientRepository Ingredients { get; }
        public IDishRepository Dishes { get; }
        public IOrderRepository Orders { get; }
        public ITableRepository Tables { get; }

        public UnitOfWork(DbContext context, IIngredientRepository ingredients, IDishRepository dishes, IOrderRepository orders, ITableRepository tables)
        {
            _context = context;
            Ingredients = ingredients;
            Dishes = dishes;
            Orders = orders;
            Tables = tables;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
