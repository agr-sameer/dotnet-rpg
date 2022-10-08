using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_rpg.Migrations
{
    public partial class SkillSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Damage", "SkillName" },
                values: new object[] { 1, 5, "FireBall" });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Damage", "SkillName" },
                values: new object[] { 2, 3, "WaterJet" });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Damage", "SkillName" },
                values: new object[] { 3, 8, "Blizzard" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
