using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class MaterialType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserMaterialTypes",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    MaterialTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaterialTypes", x => new { x.UserId, x.MaterialTypeId });
                    table.ForeignKey(
                        name: "FK_UserMaterialTypes_MaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMaterialTypes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMaterialTypes_MaterialTypeId",
                table: "UserMaterialTypes",
                column: "MaterialTypeId");
            migrationBuilder.Sql(
               @"
                    INSERT INTO MaterialTypes Values ('Plastic')
               ");
            migrationBuilder.Sql(
               @"
                    INSERT INTO MaterialTypes Values ('Paper')
               ");
            migrationBuilder.Sql(
               @"
                    INSERT INTO MaterialTypes Values ('Metal')
               ");
            migrationBuilder.Sql(
               @"
                    INSERT INTO MaterialTypes Values ('Textiles')
               ");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMaterialTypes");

            migrationBuilder.DropTable(
                name: "MaterialTypes");
        }
    }
}
