using Microsoft.EntityFrameworkCore.Migrations;
using SietReals.Controllers;

namespace SietReals.Migrations
{
    public partial class seeasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContextId",
                table: "Data",
                newName: "ContextType");

            (new DbConnector()).Init();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContextType",
                table: "Data",
                newName: "ContextId");
        }
    }
}
