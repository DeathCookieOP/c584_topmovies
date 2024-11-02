using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModel.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producer_Company",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    founded_year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    release_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movies_Producers",
                        column: x => x.company_id,
                        principalTable: "Producer_Company",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_company_id",
                table: "Movies",
                column: "company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Producer_Company");
        }
    }
}
