using BLL.Infrastructures;
using BLL.Interfaces;
using DAL.DB;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository repository;

        private readonly UserManager<User> userManager;

        public AccountService(IRepository repo, UserManager<User> userManager)
        {
            this.repository = repo;
            this.userManager = userManager;
        }

        public ClaimsIdentity Authenticate(string email, string password)
        {
            ClaimsIdentity claim = null;
            User user = this.userManager.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {

            }
            else if (this.userManager.CheckPasswordAsync(user, password).Result)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
                };
                claim =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            }
            return claim;
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public User GetInfo(string email) =>
            this.userManager.FindByEmailAsync(email).Result;


        public async Task<OperationDetails> RegisterAsync(string login, string password, string email)
        {
            User user = await this.userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return new OperationDetails(false, "EmailAlreadyExist");
            }
            user = new User
            {
                Email = email,
                UserName = login
            };
            var result = await this.userManager.CreateAsync(user, password);
            if (result.Errors.Count() > 0)
                return new OperationDetails(false, "InvalidRegistration");
            return new OperationDetails(true, "SuccessfulRegistration");
        }

        ClaimsIdentity IAccountService.Authenticate(string login, string password)
        {
            throw new NotImplementedException();
        }

        Task<OperationDetails> IAccountService.RegisterAsync(string login, string password, string email)
        {
            throw new NotImplementedException();
        }
    }
}
