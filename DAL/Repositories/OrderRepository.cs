using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using BLL.Exceptions;
using DAL.Entity_Framework;
using DAL.Interfaces.RepositoryInterfaces;
using Order = DAL.Entities.Order;

namespace DAL.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly DbContext _context;

        public OrderRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException($"Context must be not null!");
        }

        public void Create(Order item)
        {
            _context.Set<Order>().Add(item
                         ?? throw new ArgumentNullException("Order must be not null!"));
        }

        public void Delete(int id)
        {
            var dish = Get(id);
            _context.Set<Order>().Remove(dish);
        }
        public void Update(Order file)
        {
            _context.Entry(file).State = EntityState.Modified;
        }
        public Order Get(int id)
        {
            return _context.Set<Order>().Find(id)
                   ?? throw new AbsentIdException($"Order with id = {id} was not found");
        }

        public IQueryable<Order> GetAll()
        {
            return _context.Set<Order>();
        }
    }
}
