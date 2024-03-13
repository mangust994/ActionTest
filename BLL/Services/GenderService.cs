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
    public class GenderService: IGenderService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;
        public GenderService(IRepository serializer)
        {
            this.repository = serializer;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new EnterpriseProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void CreateGender(GenderModel genderModel)
        {
            Gender gender = _mapper.Map<Gender>(genderModel);
            repository.AddAndSave(gender);
        }
        public IEnumerable<GenderModel> GetGenders(Expression<Func<Gender, bool>> predicate)
        {
            return _mapper.Map<List<GenderModel>>(this.repository.GetFilteredByQuery<Gender>(predicate));
        }
        public GenderModel GetGender(Expression<Func<Gender, bool>> predicate)
        {
            return _mapper.Map<GenderModel>(this.repository.FirstorDefault(predicate));
        }

        //public GenderModel GetGenderById(int id)
        //{
        //    var entity = this.repository.FirstorDefault<Gender>(x => x.Id == id);
        //    var model = new GenderModel();
        //    model.Id = entity.Id;
        //    model.Name = entity.Name;
        //    model.Description = entity.Description;
        //    return model;
        //}

        public void RemoveGender(int id)
        {
            var Gender = this.repository.FirstorDefault<Gender>(x => x.Id == id);
            if (Gender == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(Gender);
        }

        public void UpdateGender(int id, GenderModel model)
        {
            var gender = this.repository.FirstorDefault<Gender>(x => x.Id == id);
            if (gender == null)
                throw new NullReferenceException();
            gender.Id = model.Id;
            gender.Name = model.Name;
            
            this.repository.UpdateAndSave(gender);
        }
    }
}
