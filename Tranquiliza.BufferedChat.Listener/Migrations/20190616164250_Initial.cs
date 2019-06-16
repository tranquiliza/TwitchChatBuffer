using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tranquiliza.BufferedChat.Listener.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReceivedAt = table.Column<DateTime>(nullable: false),
                    Channel = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    UserColorHex = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EmoteReplacedMessage = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");
        }
    }
}
