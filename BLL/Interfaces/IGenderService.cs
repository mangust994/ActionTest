using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IGenderService
    {
        IEnumerable<GenderModel> GetGenders(Expression<Func<Gender, bool>> predicate);

        //GenderModel GetGenderById(int id);

        GenderModel GetGender(Expression<Func<Gender, bool>> predicate);

        void CreateGender(GenderModel model);

        void UpdateGender(int id, GenderModel model);

        void RemoveGender(int id);
    }
}
