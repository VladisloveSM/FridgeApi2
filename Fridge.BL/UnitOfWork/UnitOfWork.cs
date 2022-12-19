using FridgeApi.BL.Interfaces;
using FridgeApi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IFridgeRepository Fridges { get; }

        public IProductRepository Products { get; }

        public IAllAccount Accounts { get; }

        public UnitOfWork(IFridgeRepository fridges, IProductRepository products, IAllAccount accounts)
        {
            this.Fridges = fridges;
            this.Products = products;
            this.Accounts = accounts;
        }
    }
}
