using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Table : IEntity
    {
        public int Id { get; set; }
        public int PeopleAmount { get; set; }
    }
}
