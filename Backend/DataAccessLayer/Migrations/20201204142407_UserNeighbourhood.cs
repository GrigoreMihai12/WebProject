using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UserNeighbourhood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Neighbourhood",
                table: "Users",
                nullable: true);
            migrationBuilder.Sql(
                @"
                    UPDATE USERS
                    SET Neighbourhood = 'Marasti'
                    WHERE Email = 'ioan_pop@yahoo.com'
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Neighbourhood",
                table: "Users");
        }
    }
}
