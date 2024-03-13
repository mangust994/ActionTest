using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAssignmentCommentService
    {
        IEnumerable<AssignmentCommentModel> GetAssignmentComments(Expression<Func<AssignmentComment, bool>> predicate);

      

        void CreateAssignmentComment(AssignmentCommentModel model);

        void UpdateAssignmentComment(int id, AssignmentCommentModel model);

        void RemoveAssignmentComment(int id);
    }
}
