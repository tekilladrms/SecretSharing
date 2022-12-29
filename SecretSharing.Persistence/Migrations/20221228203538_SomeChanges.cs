using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecretSharing.Persistence.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileGuid",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserProfileGuid",
                table: "AspNetUsers",
                column: "UserProfileGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserProfile_UserProfileGuid",
                table: "AspNetUsers",
                column: "UserProfileGuid",
                principalTable: "UserProfile",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProfile_UserProfileGuid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserProfileGuid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserProfileGuid",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
