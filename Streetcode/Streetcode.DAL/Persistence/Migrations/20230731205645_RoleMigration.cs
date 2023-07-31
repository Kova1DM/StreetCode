using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Streetcode.DAL.Persistence.Migrations
{
    public partial class RoleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                schema: "team",
                table: "team_members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "role",
                schema: "team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_team_members_RoleId",
                schema: "team",
                table: "team_members",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_team_members_role_RoleId",
                schema: "team",
                table: "team_members",
                column: "RoleId",
                principalSchema: "team",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_team_members_role_RoleId",
                schema: "team",
                table: "team_members");

            migrationBuilder.DropTable(
                name: "role",
                schema: "team");

            migrationBuilder.DropIndex(
                name: "IX_team_members_RoleId",
                schema: "team",
                table: "team_members");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "team",
                table: "team_members");
        }
    }
}
