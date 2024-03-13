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
    public class ProjectService : IProjectService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;
        public ProjectService(IRepository serializer)
        {
            this.repository = serializer;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new EnterpriseProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void CreateProject(ProjectModel projectModel)
        {
            Project project = _mapper.Map<Project>(projectModel);
            repository.AddAndSave(project);
        }
        public IEnumerable<ProjectModel> GetProjects(Expression<Func<Project, bool>> predicate)
        {
            return _mapper.Map<List<ProjectModel>>(this.repository.GetFilteredByQuery<Project>(predicate));
        }
        public ProjectModel GetProject(Expression<Func<Project, bool>> predicate)
        {
            return _mapper.Map<ProjectModel>(this.repository.FirstorDefault(predicate));
        }

        //public ProjectModel GetProjectById(int id)
        //{
        //    var entity = this.repository.FirstorDefault<Project>(x => x.Id == id);
        //    var model = new ProjectModel();
        //    model.Id = entity.Id;
        //    model.Name = entity.Name;
        //    model.Description = entity.Description;
        //    return model;
        //}

        public void RemoveProject(int id)
        {
            var Project = this.repository.FirstorDefault<Project>(x => x.Id == id);
            if (Project == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(Project);
        }

        public void UpdateProject(int id, ProjectModel model)
        {
            var project = this.repository.FirstorDefault<Project>(x => x.Id == id);
            if (project == null)
                throw new NullReferenceException();
            project.Id = model.Id;
            project.Name = model.Name;
            project.Description = model.Description;
            project.Date = model.Date;
            this.repository.UpdateAndSave(project);
        }
    }
}
