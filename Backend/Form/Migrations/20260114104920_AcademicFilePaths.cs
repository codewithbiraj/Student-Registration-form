using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Form.Migrations
{
    /// <inheritdoc />
    public partial class AcademicFilePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharacterCertificatePath",
                table: "Academicdetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CitizenshipCopyPath",
                table: "Academicdetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Academicdetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SignaturePath",
                table: "Academicdetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterCertificatePath",
                table: "Academicdetails");

            migrationBuilder.DropColumn(
                name: "CitizenshipCopyPath",
                table: "Academicdetails");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Academicdetails");

            migrationBuilder.DropColumn(
                name: "SignaturePath",
                table: "Academicdetails");
        }
    }
}
