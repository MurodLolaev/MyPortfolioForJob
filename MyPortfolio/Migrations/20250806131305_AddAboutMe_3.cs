using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutMe_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AboutMe",
                columns: new[] { "Id", "Bio", "Contacts", "FullName", "Hobbies", "LinkedInUrl", "PhotoPath", "Skills" },
                values: new object[] { 1, "Разработчик Telegram-ботов и веб-сервисов", "murod@example.com", "Мурод Джураев", "Чтение, спорт", "https://www.linkedin.com/in/мурод-лолаев-048969345", "/images/4.png", "ASP.NET Core, SQL Server" });
        }
    }
}
