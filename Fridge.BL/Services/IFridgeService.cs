using FridgeApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL
{
    public interface IFridgeService
    {
        public IEnumerable<Product> GetProducts();

        public IEnumerable<FridgeProduct> GetProductsInFridge(Guid id);

        public void AddProduct(FridgeProduct product);

        public void DeleteProduct(Guid id);

        public void UpdateProduct(FridgeProduct product);

        public IEnumerable<Product> GetEmptyProducts(Guid fridgeId);

        public IEnumerable<Fridge> GetAllFridges();

        public string GetFridgeName(Guid id);

        public void DeleteFridge(Guid id);

        public IEnumerable<FridgeModel> GetAllModels();

        public void AddFridge(Fridge fridge);

        public void UpdateFridge(Fridge fridge);
    }
}
