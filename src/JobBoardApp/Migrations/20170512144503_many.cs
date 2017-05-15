using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobBoardApp.Migrations
{
    public partial class many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "JobUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobUser_UserId1",
                table: "JobUser",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobUser_User_UserId1",
                table: "JobUser",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobUser_User_UserId1",
                table: "JobUser");

            migrationBuilder.DropIndex(
                name: "IX_JobUser_UserId1",
                table: "JobUser");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "JobUser");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
