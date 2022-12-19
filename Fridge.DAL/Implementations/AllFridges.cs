using FridgeApi.BL.Interfaces;
using FridgeApi.DAL;
using FridgeApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL.Implementations
{
    public class AllFridges : IFridgeRepository
    {

        private readonly FridgeContext db;

        public AllFridges(FridgeContext context)
        {
            this.db = context;
        }

        public void AddFridge(Fridge fridge)
        {
            this.db.Fridges.Add(fridge);
            this.db.SaveChanges();
        }

        public void DeleteFridge(Guid id)
        {
            this.db.FridgeProducts.RemoveRange(this.db.FridgeProducts.Where(i => i.FridgeId == id));
            this.db.Fridges.Remove(this.db.Fridges.Find(id));
            this.db.SaveChanges();
        }

        public IEnumerable<Fridge> GetAllFridges()
        {
            return this.db.Fridges;
        }

        public IEnumerable<FridgeModel> GetAllModels()
        {
            return this.db.FridgeModels;
        }

        public string GetFridgeName(Guid id)
        {
            return this.db.Fridges.ToList().Find(i => i.Id == id).Name;
        }

        public void UpdateFridge(Fridge fridge)
        {
            this.db.Fridges.Update(fridge);
            this.db.SaveChanges();
        }
    }
}
