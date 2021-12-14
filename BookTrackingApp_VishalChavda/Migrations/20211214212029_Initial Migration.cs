using Microsoft.EntityFrameworkCore.Migrations;

namespace BookTrackingApp_VishalChavda.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTypes",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    NameToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.NameToken);
                    table.ForeignKey(
                        name: "FK_Categorys_CategoryTypes_Type",
                        column: x => x.Type,
                        principalTable: "CategoryTypes",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryNameToken = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Books_Categorys_CategoryNameToken",
                        column: x => x.CategoryNameToken,
                        principalTable: "Categorys",
                        principalColumn: "NameToken",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookCategoryType",
                columns: table => new
                {
                    BooksISBN = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    CategoryTypesType = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategoryType", x => new { x.BooksISBN, x.CategoryTypesType });
                    table.ForeignKey(
                        name: "FK_BookCategoryType_Books_BooksISBN",
                        column: x => x.BooksISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategoryType_CategoryTypes_CategoryTypesType",
                        column: x => x.CategoryTypesType,
                        principalTable: "CategoryTypes",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategoryType_CategoryTypesType",
                table: "BookCategoryType",
                column: "CategoryTypesType");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryNameToken",
                table: "Books",
                column: "CategoryNameToken");

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_Type",
                table: "Categorys",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategoryType");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "CategoryTypes");
        }
    }
}
