using FridgeApi.BL;
using FridgeApi.BL.Interfaces;
using FridgeApi.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IFridgeService service;

        public ProductController(IFridgeService rep)
        {
            this.service = rep;
        }

        [HttpGet("{id}")]
        public IEnumerable<FridgeProduct> AllProductsInFridge(Guid id)
        {
            return this.service.GetProductsInFridge(id);
        }

        [HttpGet("Empty/{id}")]
        public IEnumerable<Product> GetEmptyProducts(Guid id)
        {
            return this.service.GetEmptyProducts(id);
        }

        [HttpGet("All")]
        public IEnumerable<Product> AllProductType()
        {
            return this.service.GetProducts();
        }

        [HttpPost]
        public void AddProduct(FridgeProduct product)
        {
            this.service.AddProduct(product);
        }

        [HttpPut]
        public void UpdateProduct(FridgeProduct product)
        {
            this.service.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void RemoveProduct(Guid id)
        {
            this.service.DeleteProduct(id);
        }
    }
}
