using FridgeApi.BL.Models;
using FridgeApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL.Services
{
    public interface IAccountsService
    {
        public void AddAccount(Account account);

        public string GenerateAccessToken(Account account);

        public string GenerateRefreshToken(Account account);

        public string? GetRefreshToken(Account account);

        public bool ValidateLifeTimeOfToken(string token);
    }
}
