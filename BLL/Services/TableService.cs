using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TableService : ITableService
    {
        private IUnitOfWork _data;
        public TableService(IUnitOfWork data)
        {
            _data = data;
        }

        public void Create(TableDTO item)
        {
            if (item.PeopleAmount < 0) throw new NegativeNumberException("Pople amount must be more then 0. ");
            _data.Tables.Create(Mapper.Map<Table>(item));
            _data.Save();
        }

        public void Delete(int id)
        {
            var table = _data.Tables.Get(id);
            _data.Tables.Delete(id);
            _data.Save();
        }

        public void Dispose()
        {
            _data.Dispose();
        }

        public TableDTO Get(int id)
        {
            return Mapper.Map<TableDTO>(_data.Tables.Get(id));
        }

        public HashSet<TableDTO> GetAll()
        {
            return Mapper.Map<HashSet<TableDTO>>(_data.Tables.GetAll());
        }


        public void EditTable(int id, TableDTO table)
        {
            var newTable = _data.Tables.Get(id);
            if (table.PeopleAmount < 0) throw new NegativeNumberException("Pople amount must be more then 0. ");
            newTable.PeopleAmount = table.PeopleAmount;
            _data.Tables.Update(newTable);
            _data.Save();
        }
    }
}
