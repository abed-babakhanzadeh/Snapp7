﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snapp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class tblrateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RateTypes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Ok = table.Column<bool>(type: "bit", nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateTypes", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateTypes");
        }
    }
}
