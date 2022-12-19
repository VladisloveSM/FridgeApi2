using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeApi.DAL.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fridge_Model",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("29bda128-3d64-4882-a9f4-c42a089dcca9"), "Atlanta", 1998 },
                    { new Guid("c4f34e6d-2db9-4d22-aa03-d5940d5e73c5"), "Horizon", 1993 },
                    { new Guid("dace556c-2d59-490e-984e-8800b7a314b9"), "LG", 2001 },
                    { new Guid("0d540ebf-90c4-492d-839c-7a87a4a2e63f"), "Philips", 2000 },
                    { new Guid("740dd9cb-bf97-4d9d-bd61-272da57b118b"), "Panasonic", 2003 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("7b8ce319-3059-4638-b910-2c4120c4882f"), 6, "Banana" },
                    { new Guid("56e96036-8a30-4b97-92e4-ab3871d39f13"), 1, "Grape" },
                    { new Guid("e97a9683-bb43-4883-91ac-ca92f2d26aca"), 3, "Apple" },
                    { new Guid("5d449b4d-5fc5-4506-920f-f1c8f9bc5255"), 1, "Beaf" },
                    { new Guid("b46b5037-6193-492d-8a03-05c9663cccc1"), 8, "Cherry" },
                    { new Guid("60f69028-66af-47cd-91dd-4258cd6f3ec8"), 4, "Fish" }
                });

            migrationBuilder.Sql(@"CREATE PROCEDURE FindEmptyProducts
                                  @idFridge uniqueidentifier
                                  AS
	                              SELECT * FROM Products WHERE NOT EXISTS 
	                                    (SELECT * FROM Fridge_Products 
		                                WHERE Fridge_Products.ProductId = Products.Id AND Fridge_Products.FridgeId = @idFridge)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fridge_Model",
                keyColumn: "Id",
                keyValue: new Guid("0d540ebf-90c4-492d-839c-7a87a4a2e63f"));

            migrationBuilder.DeleteData(
                table: "Fridge_Model",
                keyColumn: "Id",
                keyValue: new Guid("29bda128-3d64-4882-a9f4-c42a089dcca9"));

            migrationBuilder.DeleteData(
                table: "Fridge_Model",
                keyColumn: "Id",
                keyValue: new Guid("740dd9cb-bf97-4d9d-bd61-272da57b118b"));

            migrationBuilder.DeleteData(
                table: "Fridge_Model",
                keyColumn: "Id",
                keyValue: new Guid("c4f34e6d-2db9-4d22-aa03-d5940d5e73c5"));

            migrationBuilder.DeleteData(
                table: "Fridge_Model",
                keyColumn: "Id",
                keyValue: new Guid("dace556c-2d59-490e-984e-8800b7a314b9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56e96036-8a30-4b97-92e4-ab3871d39f13"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5d449b4d-5fc5-4506-920f-f1c8f9bc5255"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60f69028-66af-47cd-91dd-4258cd6f3ec8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b8ce319-3059-4638-b910-2c4120c4882f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b46b5037-6193-492d-8a03-05c9663cccc1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e97a9683-bb43-4883-91ac-ca92f2d26aca"));

            migrationBuilder.Sql(@"DROP PROCEDURE FindEmptyProducts");
        }
    }
}
