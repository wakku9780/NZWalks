using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "egionImageUrl",
                table: "Regions",
                newName: "RegionImageUrl");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("cdb28247-441e-4301-80df-1f19d6ad8749"), "Hard" },
                    { new Guid("cdb28247-441e-4301-80df-1f19d6ad8849"), "Easy" },
                    { new Guid("cdb28247-441e-4301-80df-1f19d6ad8850"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("a1e28247-441e-4301-80df-1f19d6ad8749"), "AKL", "Auckland", "wwwwww" },
                    { new Guid("b1e28247-441e-4301-80df-1f19d6ad8749"), "WKL", "Wellington", "wwwwww" },
                    { new Guid("c1e28247-441e-4301-80df-1f19d6ad8749"), "M.P", "Mubarakpur", "wwwwww" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cdb28247-441e-4301-80df-1f19d6ad8749"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cdb28247-441e-4301-80df-1f19d6ad8849"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cdb28247-441e-4301-80df-1f19d6ad8850"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1e28247-441e-4301-80df-1f19d6ad8749"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b1e28247-441e-4301-80df-1f19d6ad8749"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c1e28247-441e-4301-80df-1f19d6ad8749"));

            migrationBuilder.RenameColumn(
                name: "RegionImageUrl",
                table: "Regions",
                newName: "egionImageUrl");
        }
    }
}
