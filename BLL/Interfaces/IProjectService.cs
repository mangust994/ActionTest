using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectModel> GetProjects(Expression<Func<Project, bool>> predicate);

        //ProjectModel GetProjectById(int id);

        ProjectModel GetProject(Expression<Func<Project, bool>> predicate);

        void CreateProject(ProjectModel model);

        void UpdateProject(int id, ProjectModel model);

        void RemoveProject(int id);

    }
}
