using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Migrations
{
    /// <inheritdoc />
    public partial class post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Assignments_Assignmentid",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Tests_TestModelid",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_Assignmentid",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_TestModelid",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Assignmentid",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestModelid",
                table: "Tests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Assignmentid",
                table: "Tests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestModelid",
                table: "Tests",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_Assignmentid",
                table: "Tests",
                column: "Assignmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestModelid",
                table: "Tests",
                column: "TestModelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Assignments_Assignmentid",
                table: "Tests",
                column: "Assignmentid",
                principalTable: "Assignments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Tests_TestModelid",
                table: "Tests",
                column: "TestModelid",
                principalTable: "Tests",
                principalColumn: "id");
        }
    }
}
