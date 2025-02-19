using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZwalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7b2ce3d4-ac0e-4ba9-8e2f-0893e3e07494"), "Easy" },
                    { new Guid("9acb62ce-7179-4f50-b87d-890103cf0afd"), "Hard" },
                    { new Guid("f4a3f97d-1ba2-460c-8e04-df12b9c42993"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionPhotoUrl" },
                values: new object[,]
                {
                    { new Guid("2ad74d70-03a4-48b2-b588-2536eda00b7c"), "NTL", "Northland", null },
                    { new Guid("4dad0347-c7c1-45ff-aba7-ea3446cbae3c"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("5f5a68b1-3a42-4cd5-9b4c-2fe15b75045b"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("7ef4e2d0-e544-4b12-a2bd-d2b84a9f9df2"), "BOP", "Bay Of Plenty", null },
                    { new Guid("8828a69c-4b39-4c59-85f4-0c787b57e034"), "STL", "Southland", null },
                    { new Guid("efeab7f7-2132-4234-8898-7e22ed7c65b8"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7b2ce3d4-ac0e-4ba9-8e2f-0893e3e07494"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9acb62ce-7179-4f50-b87d-890103cf0afd"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f4a3f97d-1ba2-460c-8e04-df12b9c42993"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2ad74d70-03a4-48b2-b588-2536eda00b7c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4dad0347-c7c1-45ff-aba7-ea3446cbae3c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5f5a68b1-3a42-4cd5-9b4c-2fe15b75045b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7ef4e2d0-e544-4b12-a2bd-d2b84a9f9df2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8828a69c-4b39-4c59-85f4-0c787b57e034"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("efeab7f7-2132-4234-8898-7e22ed7c65b8"));
        }
    }
}
