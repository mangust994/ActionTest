using BLL.Interfaces;
using BLL.Services;
using DAL.DB;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Text;



namespace BLL
{
    public class IoCResolver
    {
        /// <summary>
        /// DI Register from DAL and BLL
        /// </summary>
        public static void Load(IServiceCollection services, string connection)
        {
            
            services.AddDbContext<DeeplomContext>(options => options.UseSqlServer(connection));
            services.AddScoped<DeeplomContext>();
            services.AddScoped<IRepository, EfRepository>();
            services.AddScoped<IAssignmentCommentService, AssignmentCommentService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<ICompanyDepartmentService, CompanyDepartmentService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
