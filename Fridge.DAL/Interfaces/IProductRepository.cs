using FridgeApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();

        public IEnumerable<FridgeProduct> GetProductsInFridge(Guid id);

        public void AddProduct(FridgeProduct product);

        public void DeleteProduct(Guid id);

        public void UpdateProduct(FridgeProduct product);

        public IEnumerable<Product> GetEmptyProducts(Guid fridgeId);
    }
}
