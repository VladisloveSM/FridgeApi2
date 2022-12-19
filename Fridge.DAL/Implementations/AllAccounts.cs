using FridgeApi.DAL.Interfaces;
using FridgeApi.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.DAL.Implementations
{
    public class AllAccounts : IAllAccount
    {
        private readonly FridgeContext db;

        public AllAccounts(FridgeContext context)
        {
            this.db = context;
        }

        public void AddAccount(Account account)
        {
            this.db.Accounts.Add(account);
            this.db.SaveChanges();
        }

        public Guid FindAccount(Account account)
        {
            Account result = this.db.Accounts.First(a => a.Id == account.Id || a.Hash == account.Hash && a.Name == account.Name);
            if (result == null)
            {
                throw new ArgumentException(nameof(account));
            }
            return result.Id;
        }

        public string? GetRefreshToken(Account account)
        {
            Account result = this.db.Accounts.FirstOrDefault(a => a.Id == account.Id);
            return result.RefreshToken;
        }

        public void UpdateToken(Guid accountId, string refreshToken)
        {
            Account result = this.db.Accounts.FirstOrDefault(a => a.Id == accountId);
            result.RefreshToken = refreshToken;
            db.SaveChanges();
        }

        public bool ValidateTokenLifeTime(string refresh)
        {
            var stream = refresh;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            return tokenS.ValidTo.AddHours(3) >= DateTime.Now;
        }
    }
}
