using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registeration.Migrations
{
    public partial class addFileToMailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "DataFile",
                table: "Mails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Mails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Mails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFile",
                table: "Mails");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Mails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Mails");
        }
    }
}
