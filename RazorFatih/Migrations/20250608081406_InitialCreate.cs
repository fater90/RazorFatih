using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorFatih.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeContents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HomeContents",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { 1, "RazorFatih uygulamanıza hoş geldiniz. Bu sayfanın içeriğini kolayca düzenleyebilir ve uygulamanız hakkında bilgi verebilirsiniz. Gelecekteki güncellemeler ve özellikler için bizi takipte kalın!", "Hoş Geldiniz!" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeContents");
        }
    }
}
