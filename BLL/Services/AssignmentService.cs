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
    public class AssignmentService: IAssignmentService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;
        public AssignmentService(IRepository serializer)
        {
            this.repository = serializer;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new EnterpriseProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void CreateAssignment(AssignmentModel AssignmentModel)
        {
            Assignment assignment = _mapper.Map<Assignment>(AssignmentModel);
            repository.AddAndSave(assignment);
        }
        public IEnumerable<AssignmentModel> GetAssignments(Expression<Func<Assignment, bool>> predicate)
        {
            return _mapper.Map<List<AssignmentModel>>(this.repository.GetFilteredByQuery<Assignment>(predicate));
        }
        public AssignmentModel GetAssignment(Expression<Func<Assignment, bool>> predicate)
        {
            return _mapper.Map<AssignmentModel>(this.repository.FirstorDefault(predicate));
        }

        

        public void RemoveAssignment(int id)
        {
            var Assignment = this.repository.FirstorDefault<Assignment>(x => x.Id == id);
            if (Assignment == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(Assignment);
        }

        public void UpdateAssignment(int id, AssignmentModel model)
        {
            var assignment = this.repository.FirstorDefault<Assignment>(x => x.Id == id);
            if (assignment == null)
                throw new NullReferenceException();
            assignment.Id = model.Id;
            assignment.Name = model.Name;
            assignment.Description = model.Description;
            assignment.Date = model.Date;
            this.repository.UpdateAndSave(assignment);
        }

       
    }
}
