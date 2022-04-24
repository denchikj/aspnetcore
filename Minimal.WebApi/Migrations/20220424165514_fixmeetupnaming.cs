using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minimal.WebApi.Migrations
{
    public partial class fixmeetupnaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Topic",
                table: "Meetups",
                newName: "topic");

            migrationBuilder.RenameColumn(
                name: "Place",
                table: "Meetups",
                newName: "place");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Meetups",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Meetups",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "topic",
                table: "Meetups",
                newName: "Topic");

            migrationBuilder.RenameColumn(
                name: "place",
                table: "Meetups",
                newName: "Place");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Meetups",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Meetups",
                newName: "Id");
        }
    }
}
