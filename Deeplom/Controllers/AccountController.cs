﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.Services;
using BLL.Models;
using System.Threading.Tasks;
using BLL.Interfaces;


namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService accService;

        public AccountController(IAccountService service)
        {
            this.accService = service;
        }



        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.accService.RegisterAsync(model.Login, model.Password, model.Email);
            if (result.Succedeed)
            {
                return Ok();
            }
            ModelState.AddModelError("", result.Message);
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var claim = this.accService.Authenticate(model.Email, model.Password);
            if (claim == null)
            {
                ModelState.AddModelError("", "Invalid login or password");
                return BadRequest(ModelState);
            }
            else
            {
                var now = DateTime.UtcNow;
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: claim.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    username = claim.Name
                };

                return Json(response);
            }

        }
        [HttpGet]
        [ActionName("LogOut")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult LogOut()
        {
            return Ok();
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public UserModel UserInfo()
        {
            var result = this.accService.GetInfo(User.Identity.Name);
            var model = new UserModel
            {
                Email = result.Email,
                Name = result.NormalizedUserName
            };
            return model;
        }

    }
}
