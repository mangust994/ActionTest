using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
   public class User : IdentityUser
    {        
        public DateTime Birthday { get; set; }      
        public  Role Role { get; set; }

        public Gender Gender { get; set; }

        public CompanyDepartment Company_Department { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Project> Projects { get; set; }

        public User()
        {
            Assignments = new List<Assignment>();
            Projects = new List<Project>();
        }
    }
}
