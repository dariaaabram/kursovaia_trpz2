using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TableDTO: IEntityDTO
    {
        public int Id { get; set; }
        public int PeopleAmount { get; set; }
    }
}
