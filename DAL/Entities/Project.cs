using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public List<User> Users { get; set; }
        public List<Assignment> Assignments { get; set; }
        public Project()
        {
            Users = new List<User>();
            Assignments = new List<Assignment>();
        }
    }
}
