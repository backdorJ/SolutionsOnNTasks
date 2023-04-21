using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfiguringModels.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkPropInUserClass2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkId",
                table: "Users",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CompanyUser_WorkId",
                table: "Users",
                column: "WorkId",
                principalTable: "CompanyUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CompanyUser_WorkId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WorkId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "Users");
        }
    }
}
