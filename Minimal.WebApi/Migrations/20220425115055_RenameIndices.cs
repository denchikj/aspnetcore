using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minimal.WebApi.Migrations
{
    public partial class RenameIndices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Meetups",
                newName: "meetups");

            migrationBuilder.RenameIndex(
                name: "pk_users",
                table: "users",
                newName: "pk_users");

            migrationBuilder.RenameIndex(
                name: "ix_users_username",
                table: "users",
                newName: "ix_users_username");

            migrationBuilder.RenameIndex(
                name: "pk_refresh_tokens",
                table: "refresh_tokens",
                newName: "pk_refresh_tokens");

            migrationBuilder.RenameIndex(
                name: "pk_meetups",
                table: "meetups",
                newName: "pk_meetups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "meetups",
                newName: "Meetups");

            migrationBuilder.RenameIndex(
                name: "pk_users",
                table: "users",
                newName: "PK_users");

            migrationBuilder.RenameIndex(
                name: "ix_users_username",
                table: "users",
                newName: "IX_users_username");

            migrationBuilder.RenameIndex(
                name: "pk_refresh_tokens",
                table: "refresh_tokens",
                newName: "PK_refresh_tokens");

            migrationBuilder.RenameIndex(
                name: "pk_meetups",
                table: "meetups",
                newName: "PK_meetups");
        }
    }
}
