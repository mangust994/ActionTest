using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Assignment: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public List<User> Users { get; set; }
        public List<Project> Projects { get; set; }

        public List<AssignmentComment> AssignmentComments { get; set; }

        public Assignment()
        {
            this.Users = new List<User>();
            this.Projects = new List<Project>();
            this.AssignmentComments = new List<AssignmentComment>();
        }
    }
}
