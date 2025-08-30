using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class Changes4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "City", "Email", "GitHub", "Linkedin", "Phone", "Telegram", "Whatsapp", "Youtube" },
                values: new object[] { 1, "A.Сино хонаи 4 ошёна 1", "Душанбе", "murod99_99@bk.ru", "https://github.com/NikClouse?tab=repositories", "https://www.linkedin.com/in/мурод-лолаев-048969345", "+992985630599", "+992985630599", "+992985630599", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
