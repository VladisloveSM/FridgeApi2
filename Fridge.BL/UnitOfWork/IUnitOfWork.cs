using FridgeApi.BL.Interfaces;
using FridgeApi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL
{
    public interface IUnitOfWork
    {
        public IFridgeRepository Fridges { get; }

        public IProductRepository Products { get; }
        
        public IAllAccount Accounts { get; }
    }
}
