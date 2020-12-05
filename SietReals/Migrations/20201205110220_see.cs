using Microsoft.EntityFrameworkCore.Migrations;

namespace SietReals.Migrations
{
    public partial class see : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageTuple",
                table: "ImageTuple");

            migrationBuilder.RenameTable(
                name: "ImageTuple",
                newName: "Data");

            migrationBuilder.AddColumn<int>(
                name: "ContextId",
                table: "Data",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Data",
                table: "Data",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Data",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "ContextId",
                table: "Data");

            migrationBuilder.RenameTable(
                name: "Data",
                newName: "ImageTuple");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageTuple",
                table: "ImageTuple",
                column: "Id");
        }
    }
}
