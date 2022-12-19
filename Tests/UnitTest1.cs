using FridgeApi.BL;
using FridgeApi.BL.Interfaces;
using FridgeApi.DAL;
using FridgeApi.DAL.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using FridgeApi.DAL.Interfaces;

namespace Tests
{
    public class Tests
    {
        private IFridgeService service;

        private IUnitOfWork unitOfWork;

        private Mock<IFridgeRepository> mockFridgeRepository;

        private Mock<IProductRepository> mockProductRepository;

        private Mock<IAllAccount> mockAccountsRepository;

        private readonly List<FridgeModel> models = new List<FridgeModel>
        {
                    new FridgeModel
                    {
                        Id = new Guid("29bda128-3d64-4882-a9f4-c42a089dcca9"),
                        Name = "Atlanta",
                        Year = 1998
                    },
                    new FridgeModel
                    {
                        Id = new Guid("c4f34e6d-2db9-4d22-aa03-d5940d5e73c5"),
                        Name = "Horizon",
                        Year = 1993
                    },
                    new FridgeModel
                    {
                        Id = new Guid("dace556c-2d59-490e-984e-8800b7a314b9"),
                        Name = "LG",
                        Year = 2001
                    },
                    new FridgeModel
                    {
                        Id = new Guid("0d540ebf-90c4-492d-839c-7a87a4a2e63f"),
                        Name = "Philips",
                        Year = 2000
                    },
                    new FridgeModel
                    {
                        Id = new Guid("740dd9cb-bf97-4d9d-bd61-272da57b118b"),
                        Name = "Panasonic",
                        Year = 2003
                    }
        };

        private readonly List<Fridge> fridges = new List<Fridge>
        {
            new Fridge
            {
                Id = new Guid("adbda128-3d64-4882-a9f4-c42a089dcca9"),
                Name = "TestFridge",
                OwnerName = "TestOwner",
                ModelId = new Guid("29bda128-3d64-4882-a9f4-c42a089dcca9")
            },
            new Fridge
            {
                Id = new Guid("adbda121-2414-4882-a9f4-c42a089dcca9"),
                Name = "TestFridge2",
                OwnerName = "TestOwner2",
                ModelId = new Guid("29bda128-3d64-4882-a9f4-c42a089dcca9")
            }
        };

        private readonly List<Product> typeProducts = new List<Product>
        {
            new Product { Id = new Guid("7b8ce319-3059-4638-b910-2c4120c4882f"), DefaultQuantity = 6, Name = "Banana" },
            new Product { Id = new Guid("56e96036-8a30-4b97-92e4-ab3871d39f13"), DefaultQuantity = 1, Name = "Grape" },
            new Product { Id = new Guid("e97a9683-bb43-4883-91ac-ca92f2d26aca"), DefaultQuantity = 3, Name = "Apple" },
            new Product { Id = new Guid("5d449b4d-5fc5-4506-920f-f1c8f9bc5255"), DefaultQuantity = 1, Name = "Beaf" },
            new Product { Id = new Guid("b46b5037-6193-492d-8a03-05c9663cccc1"), DefaultQuantity = 8, Name = "Cherry" },
            new Product { Id = new Guid("60f69028-66af-47cd-91dd-4258cd6f3ec8"), DefaultQuantity = 4, Name = "Fish" }
        };

        private readonly List<FridgeProduct> productsInFridge = new List<FridgeProduct>
        {
            new FridgeProduct
            {
                Id = new Guid("29bda128-3d64-4882-a9f4-c42a089dc000"),
                Quantity = 708,
                ProductId = new Guid("7b8ce319-3059-4638-b910-2c4120c4882f"),
                FridgeId = new Guid("adbda128-3d64-4882-a9f4-c42a089dcca9")
            },
            new FridgeProduct
            {
                Id = new Guid("29bda128-3d64-4882-a9f4-c42a089dc001"),
                Quantity = 216,
                ProductId = new Guid("56e96036-8a30-4b97-92e4-ab3871d39f13"),
                FridgeId = new Guid("adbda128-3d64-4882-a9f4-c42a089dcca9")
            },
            new FridgeProduct
            {
                Id = new Guid("29bda128-3d64-4882-a9f4-c42a089dc002"),
                Quantity = 404,
                ProductId = new Guid("5d449b4d-5fc5-4506-920f-f1c8f9bc5255"),
                FridgeId = new Guid("adbda121-2414-4882-a9f4-c42a089dcca9")
            },
        };

        [SetUp] 
        public void Setup()
        {
            mockFridgeRepository = new Mock<IFridgeRepository>();
            mockProductRepository = new Mock<IProductRepository>();
            mockAccountsRepository = new Mock<IAllAccount>();

            mockFridgeRepository.Setup(x => x.GetAllModels()).Returns(this.models);
            mockFridgeRepository.Setup(x => x.GetAllFridges()).Returns(this.fridges);

            mockProductRepository.Setup(x => x.GetProducts()).Returns(this.typeProducts);
            mockProductRepository.Setup(x => x.AddProduct(It.IsAny<FridgeProduct>()));

            unitOfWork = new UnitOfWork(mockFridgeRepository.Object, mockProductRepository.Object, mockAccountsRepository.Object);
            service = new FridgeService(unitOfWork);
        }

        [Test]
        public void TestFridgeModels()
        {
            //Arrage
            //Act
            var result = this.service.GetAllModels();
            //Assert
            Assert.AreEqual(result, this.models);
        }

        [Test]
        public void AddFridge()
        {
            //Arrage
            //Act
            List<Fridge> result = this.service.GetAllFridges().ToList();
            //Assert
            Assert.AreEqual(result, this.fridges);
        }

        [Test]
        public void TestProducts()
        {
            //Arrage
            //Act
            List<Product> products = this.service.GetProducts().ToList();
            //Assert
            Assert.AreEqual(products, this.typeProducts);
        }

        [Test]
        public void TestAddProduct()
        {
            //Arrage
            //Act
            this.service.AddProduct(this.productsInFridge[0]);
            //Assert
            mockProductRepository.Verify(x => x.AddProduct(It.IsAny<FridgeProduct>()), Times.Once);
        }
    }
}