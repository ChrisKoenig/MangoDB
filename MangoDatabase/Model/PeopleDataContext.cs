using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace MangoDatabase.Model
{
    public class PeopleDataContext : DataContext
    {
        public PeopleDataContext()
            : base("Data Source=isostore:/PeopleData.sdf")
        {
        }

        public Table<Person> People;
    }
}