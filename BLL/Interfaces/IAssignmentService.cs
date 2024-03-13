using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAssignmentService
    {
        IEnumerable<AssignmentModel> GetAssignments(Expression<Func<Assignment, bool>> predicate);

        //AssignmentModel GetAssignmentById(int id);

        AssignmentModel GetAssignment(Expression<Func<Assignment, bool>> predicate);

        void CreateAssignment(AssignmentModel model);

        void UpdateAssignment(int id, AssignmentModel model);

        void RemoveAssignment(int id);
    }
}
