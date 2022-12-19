using FridgeApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.DAL.Interfaces
{
    public interface IAllAccount
    {
        public void AddAccount(Account account);

        public Guid FindAccount(Account account);

        public void UpdateToken(Guid accountId, string refreshToken);

        public string? GetRefreshToken(Account account);

        public bool ValidateTokenLifeTime(string refresh);
    }
}
