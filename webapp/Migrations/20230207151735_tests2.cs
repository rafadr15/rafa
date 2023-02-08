using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Migrations
{
    /// <inheritdoc />
    public partial class tests2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectModel",
                table: "SubjectModel");

            migrationBuilder.RenameTable(
                name: "SubjectModel",
                newName: "Subjects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    TestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Assignmentid = table.Column<string>(type: "text", nullable: false),
                    TestModelid = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tests_Assignments_Assignmentid",
                        column: x => x.Assignmentid,
                        principalTable: "Assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tests_Tests_TestModelid",
                        column: x => x.TestModelid,
                        principalTable: "Tests",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_Assignmentid",
                table: "Tests",
                column: "Assignmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestModelid",
                table: "Tests",
                column: "TestModelid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "SubjectModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectModel",
                table: "SubjectModel",
                column: "id");
        }
    }
}
