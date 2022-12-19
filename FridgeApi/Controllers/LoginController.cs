using FridgeApi.BL.Models;
using FridgeApi.BL.Services;
using FridgeApi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountsService service;

        public LoginController(IAccountsService service)
        {
            this.service = service; 
        }

        [HttpPost]
        public void AddAccount(Account account)
        {
            this.service.AddAccount(account);
        }

        [HttpGet]
        public Tokens Login(string name, string hash)
        {
            Account account = new Account()
            {
                Name = name,
                Hash = hash,
            };
            Tokens result = new Tokens()
            {
                Token = this.service.GenerateAccessToken(account),
                RefreshToken = this.service.GenerateRefreshToken(account),
            };

            return result;
        }

        [HttpPost]
        [Route("Refresh")]
        public string GetNewAccessToken(Account account)
        {
            var currentRefreshToken = this.service.GetRefreshToken(account);

            if (currentRefreshToken == account.RefreshToken && this.service.ValidateLifeTimeOfToken(account.RefreshToken))
            {
                return this.service.GenerateAccessToken(account);
            }

            return null;
        }
    }
}
