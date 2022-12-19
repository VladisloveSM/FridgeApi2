using FridgeApi.BL.Models;
using FridgeApi.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL.Services
{
    public class AccountsService : IAccountsService
    {
        public IUnitOfWork unitOfWork { get; set; }

        private readonly IConfiguration config;

        public AccountsService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.config = configuration;
        }

        public void AddAccount(Account account)
        {
            this.unitOfWork.Accounts.AddAccount(account);
        }

        public string GenerateAccessToken(Account account)
        {
            try
            {
                Guid result = this.unitOfWork.Accounts.FindAccount(account);
                account.Id = result;
                var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", account.Id.ToString()),
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.Now.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config.GetSection("AppKey").Value)), SecurityAlgorithms.HmacSha256),
                };

                var jwt = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

                string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

                return accessToken;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GenerateRefreshToken(Account account)
        {
            try
            {
                Guid result = this.unitOfWork.Accounts.FindAccount(account);
                account.Id = result;

                var claims = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, account.Name),
                    new Claim("Id", account.Id.ToString()),
                    });


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.Now.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config.GetSection("AppKey").Value)), SecurityAlgorithms.HmacSha256),
                };

                var jwt = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

                string refreshToken = new JwtSecurityTokenHandler().WriteToken(jwt);

                this.unitOfWork.Accounts.UpdateToken(account.Id, refreshToken);

                return refreshToken;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string? GetRefreshToken(Account account)
        {
            return this.unitOfWork.Accounts.GetRefreshToken(account);
        }

        public bool ValidateLifeTimeOfToken(string token)
        {
            return this.unitOfWork.Accounts.ValidateTokenLifeTime(token);
        }
    }
}
