using FridgeApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL
{
    public class FridgeService : IFridgeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FridgeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void AddFridge(Fridge fridge)
        {
            this._unitOfWork.Fridges.AddFridge(fridge);
        }

        public void AddProduct(FridgeProduct product)
        {
            this._unitOfWork.Products.AddProduct(product);
        }

        public void DeleteFridge(Guid id)
        {
            this._unitOfWork.Fridges.DeleteFridge(id);
        }

        public void DeleteProduct(Guid id)
        {
            this._unitOfWork.Products.DeleteProduct(id);
        }

        public IEnumerable<Fridge> GetAllFridges()
        {
            return this._unitOfWork.Fridges.GetAllFridges();
        }

        public IEnumerable<FridgeModel> GetAllModels()
        {
            return this._unitOfWork.Fridges.GetAllModels();
        }

        public IEnumerable<Product> GetEmptyProducts(Guid fridgeId)
        {
            return this._unitOfWork.Products.GetEmptyProducts(fridgeId);
        }

        public string GetFridgeName(Guid id)
        {
            return this._unitOfWork.Fridges.GetFridgeName(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this._unitOfWork.Products.GetProducts();
        }

        public IEnumerable<FridgeProduct> GetProductsInFridge(Guid id)
        {
            return this._unitOfWork.Products.GetProductsInFridge(id);
        }

        public void UpdateFridge(Fridge fridge)
        {
            this._unitOfWork.Fridges.UpdateFridge(fridge);
        }

        public void UpdateProduct(FridgeProduct product)
        {
            this._unitOfWork.Products.UpdateProduct(product);
        }
    }
}
