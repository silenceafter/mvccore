using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace homeWork9.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "email");

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmailAddress = table.Column<string>(type: "character(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromId = table.Column<int>(type: "integer", nullable: false),
                    ToId = table.Column<int>(type: "integer", nullable: false),
                    Theme = table.Column<string>(type: "character(50)", nullable: false),
                    Body = table.Column<string>(type: "character varying", nullable: false),
                    IsHtml = table.Column<bool>(type: "boolean", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageTypes",
                schema: "email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "email",
                table: "Contacts",
                columns: new[] { "Id", "EmailAddress" },
                values: new object[,]
                {
                    { 1, "a59-info@yandex.ru" },
                    { 2, "silenceafter@yandex.ru" },
                    { 3, "axasthur89@mail.ru" },
                    { 4, "a8959@mail.ru" },
                    { 5, "a25031992@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "email",
                table: "MessageTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Incoming" },
                    { 2, "Outgoing" }
                });

            migrationBuilder.InsertData(
                schema: "email",
                table: "Messages",
                columns: new[] { "Id", "Body", "FromId", "IsHtml", "Theme", "ToId", "TypeId" },
                values: new object[,]
                {
                    { 1, "Body1", 1, false, "Theme1", 2, 1 },
                    { 2, "Body2", 3, false, "Theme2", 1, 2 },
                    { 3, "Body3", 2, false, "Theme3", 3, 1 },
                    { 4, "Body4", 4, false, "Theme4", 2, 2 },
                    { 5, "Body5", 3, false, "Theme5", 1, 1 },
                    { 6, "Body6", 5, false, "Theme6", 3, 2 },
                    { 7, "Body7", 4, false, "Theme7", 2, 1 },
                    { 8, "Body8", 3, false, "Theme8", 4, 2 },
                    { 9, "Body9", 5, false, "Theme9", 1, 1 },
                    { 10, "Body10", 5, false, "Theme10", 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmailAddress",
                schema: "email",
                table: "Contacts",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageTypes_Name",
                schema: "email",
                table: "MessageTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "email");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "email");

            migrationBuilder.DropTable(
                name: "MessageTypes",
                schema: "email");
        }
    }
}
