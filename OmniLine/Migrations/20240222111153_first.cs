using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniLine.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CounterAgents",
                columns: table => new
                {
                    CounterAgentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEdit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterAgents", x => x.CounterAgentId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEdit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CounterAgentId = table.Column<long>(type: "bigint", nullable: true),
                    CounterAgent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_CounterAgents_CounterAgentId",
                        column: x => x.CounterAgentId,
                        principalTable: "CounterAgents",
                        principalColumn: "CounterAgentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CounterAgentId",
                table: "Contacts",
                column: "CounterAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Email",
                table: "Contacts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CounterAgents_Name",
                table: "CounterAgents",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CounterAgents");
        }
    }
}
