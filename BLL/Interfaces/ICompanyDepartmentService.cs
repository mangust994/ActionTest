using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICompanyDepartmentService
    {
        IEnumerable<CompanyDepartmentModel> GetCompanyDepartments(Expression<Func<CompanyDepartment, bool>> predicate);

        //CompanyDepartmentModel GetCompanyDepartmentById(int id);

        CompanyDepartmentModel GetCompanyDepartment(Expression<Func<CompanyDepartment, bool>> predicate);

        void CreateCompanyDepartment(CompanyDepartmentModel model);

        void UpdateCompanyDepartment(int id, CompanyDepartmentModel model);

        void RemoveCompanyDepartment(int id);
    }
}
