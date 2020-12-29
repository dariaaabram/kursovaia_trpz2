using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using BLL.Exceptions;
using DAL.Entity_Framework;
using DAL.Interfaces.RepositoryInterfaces;
using Table = DAL.Entities.Table;

namespace DAL.Repositories
{
    public class TableRepository:ITableRepository
    {
        private readonly DbContext _context;

        public TableRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException($"Context must be not null!");
        }

        public void Create(Table item)
        {
            _context.Set<Table>().Add(item
                         ?? throw new ArgumentNullException("Table must be not null!"));
        }

        public void Delete(int id)
        {
            var dish = Get(id);
            _context.Set<Table>().Remove(dish);
        }
        public void Update(Table file)
        {
            _context.Entry(file).State = EntityState.Modified;
        }
        public Table Get(int id)
        {
            return _context.Set<Table>().Find(id)
                   ?? throw new AbsentIdException($"Table with id = {id} was not found");
        }

        public IQueryable<Table> GetAll()
        {
            return _context.Set<Table>();
        }

    }
}
