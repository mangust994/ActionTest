using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.DB
{
    public class DeeplomContext : IdentityDbContext<User>
    {
        public DeeplomContext(DbContextOptions<DeeplomContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<CompanyDepartment> Company_Departments { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<AssignmentComment> AssignmentComments { get; set; }

    }
}
