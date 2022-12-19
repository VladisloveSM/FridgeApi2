using FridgeApi.BL.Interfaces;
using FridgeApi.DAL;
using FridgeApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL.Implementations
{
    public class AllProducts : IProductRepository
    {
        private readonly FridgeContext db;

        public AllProducts(FridgeContext context)
        {
            this.db = context;
        }

        public void AddProduct(FridgeProduct product)
        {
            this.db.FridgeProducts.Add(product);
            this.db.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            this.db.FridgeProducts.Remove(this.db.FridgeProducts.Find(id));
            this.db.SaveChanges();
        }

        public IEnumerable<Product> GetEmptyProducts(Guid fridgeId)
        {
            IEnumerable<FridgeProduct> allProductsInFridge = this.GetProductsInFridge(fridgeId);
            List<Product> result = new List<Product>();
            foreach (Product product in this.db.Products)
            {
                bool exist = false;
                foreach (FridgeProduct productInFridge in allProductsInFridge)
                {
                    if (productInFridge.ProductId == product.Id)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.db.Products;
        }

        public IEnumerable<FridgeProduct> GetProductsInFridge(Guid id)
        {
            return this.db.FridgeProducts.Where(i => i.FridgeId == id);
        }

        public void UpdateProduct(FridgeProduct product)
        {
            this.db.FridgeProducts.Update(product);
            this.db.SaveChanges();
        }
    }
}
