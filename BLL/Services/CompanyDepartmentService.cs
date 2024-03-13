using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.DB;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Services
{
    public class CompanyDepartmentService : ICompanyDepartmentService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;
        public CompanyDepartmentService(IRepository serializer)
        {
            this.repository = serializer;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new EnterpriseProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void CreateCompanyDepartment(CompanyDepartmentModel companyDepartmentModel)
        {
            CompanyDepartment companyDepartment = _mapper.Map<CompanyDepartment>(companyDepartmentModel);
            repository.AddAndSave(companyDepartment);
        }
        public IEnumerable<CompanyDepartmentModel> GetCompanyDepartments(Expression<Func<CompanyDepartment, bool>> predicate)
        {
            return _mapper.Map<List<CompanyDepartmentModel>>(this.repository.GetFilteredByQuery<CompanyDepartment>(predicate));
        }
        public CompanyDepartmentModel GetCompanyDepartment(Expression<Func<CompanyDepartment, bool>> predicate)
        {
            return _mapper.Map<CompanyDepartmentModel>(this.repository.FirstorDefault(predicate));
        }

        //public CompanyDepartmentModel GetCompanyDepartmentById(int id)
        //{
        //    var entity = this.repository.FirstorDefault<CompanyDepartment>(x => x.Id == id);
        //    var model = new CompanyDepartmentModel();
        //    model.Id = entity.Id;
        //    model.Name = entity.Name;
        //    model.Description = entity.Description;
        //    return model;
        //}

        public void RemoveCompanyDepartment(int id)
        {
            var CompanyDepartment = this.repository.FirstorDefault<CompanyDepartment>(x => x.Id == id);
            if (CompanyDepartment == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(CompanyDepartment);
        }

        public void UpdateCompanyDepartment(int id, CompanyDepartmentModel model)
        {
            var companyDepartment = this.repository.FirstorDefault<CompanyDepartment>(x => x.Id == id);
            if (companyDepartment == null)
                throw new NullReferenceException();
            companyDepartment.Id = model.Id;
            companyDepartment.Name = model.Name;
            companyDepartment.Description = model.Description;
            companyDepartment.Address = model.Address;
            companyDepartment.CellPhone = model.CellPhone;
            this.repository.UpdateAndSave(companyDepartment);
        }
    }
}
