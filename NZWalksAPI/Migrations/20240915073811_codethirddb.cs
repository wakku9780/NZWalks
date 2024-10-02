﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class codethirddb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Walks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MaxLength",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MinLength",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "MinLength",
                table: "Walks");
        }
    }
}
