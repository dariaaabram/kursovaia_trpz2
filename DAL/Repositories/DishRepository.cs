using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using BLL.Exceptions;
using DAL.Entity_Framework;
using DAL.Interfaces.RepositoryInterfaces;
using Dish = DAL.Entities.Dish;
namespace DAL.Repositories
{
    public class DishRepository:IDishRepository
    {
        private readonly DbContext _context;

        public DishRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException($"Context must be not null!");
        }

        public void Create(Dish item)
        {
            _context.Set<Dish>().Add(item
                         ?? throw new ArgumentNullException("Dish must be not null!"));
        }

        public void Delete(int id)
        {
            var dish = Get(id);
            _context.Set<Dish>().Remove(dish);
        }
        public void Update(Dish dish)
        {
            _context.Entry(dish).State = EntityState.Modified;
        }
        public Dish Get(int id)
        {
            return _context.Set<Dish>().Find(id)
                   ?? throw new AbsentIdException($"Dish with id = {id} was not found");
        }

        public IQueryable<Dish> GetAll()
        {
            return _context.Set<Dish>();
        }
    }
}
