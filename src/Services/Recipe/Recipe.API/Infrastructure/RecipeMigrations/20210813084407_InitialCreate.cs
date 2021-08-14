using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.API.Infrastructure.RecipeMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "recipe_author_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "recipe_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "recipe_tag_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "recipe_authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "recipe_tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Value = table.Column<int>(type: "integer", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Meal = table.Column<string>(type: "text", nullable: true),
                    Img = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipes_recipe_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "recipe_authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipes_recipe_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "recipe_tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_recipes_AuthorId",
                table: "recipes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_TagId",
                table: "recipes",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "recipe_authors");

            migrationBuilder.DropTable(
                name: "recipe_tags");

            migrationBuilder.DropSequence(
                name: "recipe_author_hilo");

            migrationBuilder.DropSequence(
                name: "recipe_hilo");

            migrationBuilder.DropSequence(
                name: "recipe_tag_hilo");
        }
    }
}
