using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class Changes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AboutMe_AboutMeId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AboutMeId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AboutMeId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "AboutMeId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AboutMeId",
                table: "Projects",
                column: "AboutMeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AboutMe_AboutMeId",
                table: "Projects",
                column: "AboutMeId",
                principalTable: "AboutMe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
