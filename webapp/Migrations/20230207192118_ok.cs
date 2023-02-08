using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Migrations
{
    /// <inheritdoc />
    public partial class ok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Tests",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Assignments",
                newName: "SubjectId");

            migrationBuilder.AddColumn<float>(
                name: "Grade",
                table: "Tests",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Grade",
                table: "Assignments",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Tests",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Assignments",
                newName: "Subject");
        }
    }
}
