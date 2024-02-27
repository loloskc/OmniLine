using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniLine.Migrations
{
    public partial class ob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CounterAgents_CounterAgentId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CounterAgent",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "CounterAgentId",
                table: "CounterAgents",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CounterAgentId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Contacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CounterAgents_CounterAgentId",
                table: "Contacts",
                column: "CounterAgentId",
                principalTable: "CounterAgents",
                principalColumn: "CounterAgentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CounterAgents_CounterAgentId",
                table: "Contacts");

            migrationBuilder.AlterColumn<long>(
                name: "CounterAgentId",
                table: "CounterAgents",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "CounterAgentId",
                table: "Contacts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Contacts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CounterAgent",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CounterAgents_CounterAgentId",
                table: "Contacts",
                column: "CounterAgentId",
                principalTable: "CounterAgents",
                principalColumn: "CounterAgentId");
        }
    }
}
