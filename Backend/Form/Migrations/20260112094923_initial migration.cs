using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Form.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenshipNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenshipIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenshipIssueDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternateEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactRelation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ethinicity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disability = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Academicdetails",
                columns: table => new
                {
                    AcademicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PreviousSchool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousGrade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfCompletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    programeType = table.Column<int>(type: "int", nullable: false),
                    subjectType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academicdetails", x => x.AcademicId);
                    table.ForeignKey(
                        name: "FK_Academicdetails_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraCurricular",
                columns: table => new
                {
                    ExtraCurricularId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<int>(type: "int", nullable: false),
                    timeSlot = table.Column<int>(type: "int", nullable: false),
                    transportationMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraCurricular", x => x.ExtraCurricularId);
                    table.ForeignKey(
                        name: "FK_ExtraCurricular_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Financialdetails",
                columns: table => new
                {
                    FinancialdetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    scholarshipType = table.Column<int>(type: "int", nullable: false),
                    feeCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financialdetails", x => x.FinancialdetailsId);
                    table.ForeignKey(
                        name: "FK_Financialdetails_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parentdetails",
                columns: table => new
                {
                    ParentdetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parentdetails", x => x.ParentdetailsId);
                    table.ForeignKey(
                        name: "FK_Parentdetails_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Academicdetails_StudentId",
                table: "Academicdetails",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExtraCurricular_StudentId",
                table: "ExtraCurricular",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Financialdetails_StudentId",
                table: "Financialdetails",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parentdetails_StudentId",
                table: "Parentdetails",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Academicdetails");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ExtraCurricular");

            migrationBuilder.DropTable(
                name: "Financialdetails");

            migrationBuilder.DropTable(
                name: "Parentdetails");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
