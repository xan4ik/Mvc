using Microsoft.EntityFrameworkCore.Migrations;
using SietReals.Controllers;

namespace SietReals.Migrations
{
    public partial class seeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            (new DbConnector()).Init();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
