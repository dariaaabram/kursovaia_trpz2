using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using BLL.Exceptions;
using DAL.Entity_Framework;
using DAL.Interfaces.RepositoryInterfaces;
using Ingredient = DAL.Entities.Ingredient;

namespace DAL.Repositories
{
    public class IngredientRepository:IIngredientRepository
    {
        private readonly DbContext _context;

        public IngredientRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException($"Context must be not null!");
        }

        public void Create(Ingredient item)
        {
            _context.Set<Ingredient>().Add(item
                         ?? throw new ArgumentNullException("Ingredient must be not null!"));
        }

        public void Delete(int id)
        {
            var dish = Get(id);
            _context.Set<Ingredient>().Remove(dish);
        }
        public void Update(Ingredient file)
        {
            _context.Entry(file).State = EntityState.Modified;
        }
        public Ingredient Get(int id)
        {
            return _context.Set<Ingredient>().Find(id)
                   ?? throw new AbsentIdException($"Ingredient with id = {id} was not found");
        }

        public IQueryable<Ingredient> GetAll()
        {
            return _context.Set<Ingredient>();
        }
    }
}
