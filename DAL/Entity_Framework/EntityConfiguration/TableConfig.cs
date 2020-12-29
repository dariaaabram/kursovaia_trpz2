using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Entity_Framework.EntityConfiguration
{
    class TableConfig: EntityTypeConfiguration<Table>
    {
        public TableConfig()
        {
            Property(f => f.PeopleAmount).IsRequired();
        }
    }
}
