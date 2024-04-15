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
    public class AssignmentCommentService : IAssignmentCommentService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;
        public AssignmentCommentService(IRepository serializer)
        {
            this.repository = serializer;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new EnterpriseProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void CreateAssignmentComment(AssignmentCommentModel assignmentCommentModel)
        {
            AssignmentComment assignmentComment = _mapper.Map<AssignmentComment>(assignmentCommentModel);
            repository.AddAndSave(assignmentComment);
        }
        public IEnumerable<AssignmentCommentModel> GetAssignmentComments(Expression<Func<AssignmentComment, bool>> predicate)
        {
            return _mapper.Map<List<AssignmentCommentModel>>(this.repository.GetFilteredByQuery<AssignmentComment>(predicate));
        }


       

        public void RemoveAssignmentComment(int id)
        {
            var AssignmentComment = this.repository.FirstorDefault<AssignmentComment>(x => x.Id == id);
            
            if (AssignmentComment == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(AssignmentComment);
        }

        public void UpdateAssignmentComment(int id, AssignmentCommentModel model)
        {
            
            var assignmentComment = this.repository.FirstorDefault<AssignmentComment>(x => x.Id == id);
            if (assignmentComment == null)
                throw new NullReferenceException();
            assignmentComment.Id = model.Id;
            assignmentComment.Text = model.Text;
           
            this.repository.UpdateAndSave(assignmentComment);
        }

       
    }
}
