using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
   public class CompanyDepartment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public int CellPhone { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public CompanyDepartment()
        {
            Users = new List<User>();
        }
    }
}
