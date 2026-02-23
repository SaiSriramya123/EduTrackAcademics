using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrackAcademics.Migrations
{
    /// <inheritdoc />
    public partial class hi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentBatchAssignments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BatchId",
                table: "StudentBatchAssignments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InstructorId",
                table: "CourseBatches",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "CourseBatches",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBatchAssignments_BatchId",
                table: "StudentBatchAssignments",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBatchAssignments_StudentId",
                table: "StudentBatchAssignments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseBatches_CourseId",
                table: "CourseBatches",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseBatches_InstructorId",
                table: "CourseBatches",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseBatches_Course_CourseId",
                table: "CourseBatches",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseBatches_Instructor_InstructorId",
                table: "CourseBatches",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBatchAssignments_CourseBatches_BatchId",
                table: "StudentBatchAssignments",
                column: "BatchId",
                principalTable: "CourseBatches",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBatchAssignments_Student_StudentId",
                table: "StudentBatchAssignments",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseBatches_Course_CourseId",
                table: "CourseBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseBatches_Instructor_InstructorId",
                table: "CourseBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBatchAssignments_CourseBatches_BatchId",
                table: "StudentBatchAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBatchAssignments_Student_StudentId",
                table: "StudentBatchAssignments");

            migrationBuilder.DropIndex(
                name: "IX_StudentBatchAssignments_BatchId",
                table: "StudentBatchAssignments");

            migrationBuilder.DropIndex(
                name: "IX_StudentBatchAssignments_StudentId",
                table: "StudentBatchAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CourseBatches_CourseId",
                table: "CourseBatches");

            migrationBuilder.DropIndex(
                name: "IX_CourseBatches_InstructorId",
                table: "CourseBatches");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentBatchAssignments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BatchId",
                table: "StudentBatchAssignments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "InstructorId",
                table: "CourseBatches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "CourseBatches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
