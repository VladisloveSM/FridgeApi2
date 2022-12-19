using FridgeApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.BL.Interfaces
{
    public interface IFridgeRepository
    {
        public IEnumerable<Fridge> GetAllFridges();

        public string GetFridgeName(Guid id);

        public void DeleteFridge(Guid id);

        public IEnumerable<FridgeModel> GetAllModels();

        public void AddFridge(Fridge fridge);

        public void UpdateFridge(Fridge fridge);
    }
}
