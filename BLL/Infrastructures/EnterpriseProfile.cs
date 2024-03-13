using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System;

namespace BLL
{
    public class EnterpriseProfile : Profile
    {
        public EnterpriseProfile()
        {
            CreateMap<Assignment, AssignmentModel>().ReverseMap();
            CreateMap<AssignmentComment, AssignmentCommentModel>().ReverseMap();
            CreateMap<CompanyDepartment, CompanyDepartmentModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Gender, GenderModel>().ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();
          
        }
    }
}
