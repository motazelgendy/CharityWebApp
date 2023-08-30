using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charity.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixprogramtiems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "programsItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "programsItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProgramTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_programsItems_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_programsItems_programTypes_ProgramTypeId",
                        column: x => x.ProgramTypeId,
                        principalTable: "programTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_programsItems_CategoryId",
                table: "programsItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_programsItems_ProgramTypeId",
                table: "programsItems",
                column: "ProgramTypeId");
        }
    }
}
