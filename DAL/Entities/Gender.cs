using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Gender : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        

        public Gender()
        {
            Users = new List<User>();
        }
    }
}
