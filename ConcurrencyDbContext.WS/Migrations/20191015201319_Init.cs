using Microsoft.EntityFrameworkCore.Migrations;

namespace ConcurrencyDbContext.WS.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ASD",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASD", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ASD",
                columns: new[] { "Id", "Content" },
                values: new object[] { 1, "HELLO" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ASD",
                columns: new[] { "Id", "Content" },
                values: new object[] { 2, "WORLD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASD",
                schema: "dbo");
        }
    }
}
