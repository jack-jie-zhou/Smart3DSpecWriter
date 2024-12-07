using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbtrans.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodelistTableInfoView",
                columns: table => new
                {
                    oid = table.Column<Guid>(type: "TEXT", nullable: false),
                    TableID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParentTableID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ChildTableID = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ParentTableName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ParentTableUserName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ChildTableName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ChildTableUsername = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Namespace = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    DateModified = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    Author = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CodelistValueView",
                columns: table => new
                {
                    oid = table.Column<Guid>(type: "TEXT", nullable: false),
                    TableID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParentTableID = table.Column<Guid>(type: "TEXT", nullable: true),
                    TableName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    TableUserName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ParentTableName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ParentTableUserName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ValueID = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortStringValue = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    LongStringValue = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ParentValueID = table.Column<int>(type: "INTEGER", nullable: true),
                    SortIndex = table.Column<int>(type: "INTEGER", nullable: true),
                    Namespace = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    DateCreated = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    DateModified = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    Author = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodelistTableInfoView");

            migrationBuilder.DropTable(
                name: "CodelistValueView");
        }
    }
}
