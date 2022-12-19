using FridgeApi.BL;
using FridgeApi.BL.Interfaces;
using FridgeApi.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FridgeController : ControllerBase
    {
        private readonly IFridgeService service;

        public FridgeController(IFridgeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Fridge> FridgesList()
        {
            return this.service.GetAllFridges();
        }

        [HttpGet("Name/{id}")]
        public string GetFridgeName(Guid id)
        {
            return this.service.GetFridgeName(id);
        }

        [HttpDelete("{id}")]
        public void DeleteFridge(Guid id)
        {
            this.service.DeleteFridge(id);
        }

        [HttpPost]
        public void CreateFridge(Fridge fridge)
        {
            this.service.AddFridge(fridge);
        }

        [HttpPut]
        public void UpdateFridge(Fridge fridge)
        {
            this.service.UpdateFridge(fridge);
        }

        [HttpGet("Models")]
        public IEnumerable<FridgeModel> GetAllModels()
        {
            return this.service.GetAllModels();
        }
    }
}
