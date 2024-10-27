using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using testBekind.Application.Ports;
using testBekind.Domain;
using testBekind.Domain.DTO;
using testBekind.Domain.Enum;

namespace testBekindServices.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthenticationController
    {
        private IUserPort _userPort;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration, IUserPort userPort)
        {
            _configuration = configuration;
            _userPort = userPort;
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<dynamic> Login(LogInDTO logIn)
        {
            var user = await _userPort.GetUserByNameAsync(logIn.UserName);

            if (user == null)
                return new { code = "Unauthorized"  };

            if (user.Pwd == logIn.Password) {

                var token = GenerateJwtToken(user);
                return new { code= "Success", Token = token };

            }



            return new { code = "Unauthorized" };


        }

        [Authorize(Policy = Permissions.Admin)]
        [HttpPost]
        public async Task Add(User user)
        {
            await _userPort.AddUserAsync(user);
        }


        [Authorize(Policy = Permissions.Admin)]
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
           return  await _userPort.GetAllUserAsync();
        }



        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(ClaimTypes.Role, user.Rol),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }



}
