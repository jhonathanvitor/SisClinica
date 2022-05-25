using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisClin.Infra.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyProperty",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProperty", x => x.AttendanceId);
                });

            migrationBuilder.CreateTable(
                name: "PeoplesAttendances",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeoplesAttendances", x => new { x.AttendanceId, x.PeopleId });
                });

            migrationBuilder.CreateTable(
                name: "ProceduresAttendances",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProceduresAttendances", x => new { x.AttendanceId, x.ProcedureId });
                });

            migrationBuilder.CreateTable(
                name: "Tipes",
                columns: table => new
                {
                    TipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipes", x => x.TipeId);
                });

            migrationBuilder.CreateTable(
                name: "AttendancePeopleAttendance",
                columns: table => new
                {
                    AttendancesAttendanceId = table.Column<int>(type: "int", nullable: false),
                    PeoplesAttendancesAttendanceId = table.Column<int>(type: "int", nullable: false),
                    PeoplesAttendancesPeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePeopleAttendance", x => new { x.AttendancesAttendanceId, x.PeoplesAttendancesAttendanceId, x.PeoplesAttendancesPeopleId });
                    table.ForeignKey(
                        name: "FK_AttendancePeopleAttendance_MyProperty_AttendancesAttendanceId",
                        column: x => x.AttendancesAttendanceId,
                        principalTable: "MyProperty",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendancePeopleAttendance_PeoplesAttendances_PeoplesAttendancesAttendanceId_PeoplesAttendancesPeopleId",
                        columns: x => new { x.PeoplesAttendancesAttendanceId, x.PeoplesAttendancesPeopleId },
                        principalTable: "PeoplesAttendances",
                        principalColumns: new[] { "AttendanceId", "PeopleId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeopleRg = table.Column<float>(type: "real", nullable: false),
                    PeopleCpf = table.Column<float>(type: "real", nullable: false),
                    PeopleAndress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendanceId = table.Column<int>(type: "int", nullable: true),
                    PeopleAttendanceAttendanceId = table.Column<int>(type: "int", nullable: true),
                    PeopleAttendancePeopleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.PeopleId);
                    table.ForeignKey(
                        name: "FK_Peoples_MyProperty_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "MyProperty",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Peoples_PeoplesAttendances_PeopleAttendanceAttendanceId_PeopleAttendancePeopleId",
                        columns: x => new { x.PeopleAttendanceAttendanceId, x.PeopleAttendancePeopleId },
                        principalTable: "PeoplesAttendances",
                        principalColumns: new[] { "AttendanceId", "PeopleId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceProcedureAttendance",
                columns: table => new
                {
                    AttendancesAttendanceId = table.Column<int>(type: "int", nullable: false),
                    ProceduresAttendancesAttendanceId = table.Column<int>(type: "int", nullable: false),
                    ProceduresAttendancesProcedureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceProcedureAttendance", x => new { x.AttendancesAttendanceId, x.ProceduresAttendancesAttendanceId, x.ProceduresAttendancesProcedureId });
                    table.ForeignKey(
                        name: "FK_AttendanceProcedureAttendance_MyProperty_AttendancesAttendanceId",
                        column: x => x.AttendancesAttendanceId,
                        principalTable: "MyProperty",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceProcedureAttendance_ProceduresAttendances_ProceduresAttendancesAttendanceId_ProceduresAttendancesProcedureId",
                        columns: x => new { x.ProceduresAttendancesAttendanceId, x.ProceduresAttendancesProcedureId },
                        principalTable: "ProceduresAttendances",
                        principalColumns: new[] { "AttendanceId", "ProcedureId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureDescliption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcedureValue = table.Column<float>(type: "real", nullable: false),
                    AttendanceId = table.Column<int>(type: "int", nullable: true),
                    ProcedureAttendanceAttendanceId = table.Column<int>(type: "int", nullable: true),
                    ProcedureAttendanceProcedureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.ProcedureId);
                    table.ForeignKey(
                        name: "FK_Procedures_MyProperty_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "MyProperty",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedures_ProceduresAttendances_ProcedureAttendanceAttendanceId_ProcedureAttendanceProcedureId",
                        columns: x => new { x.ProcedureAttendanceAttendanceId, x.ProcedureAttendanceProcedureId },
                        principalTable: "ProceduresAttendances",
                        principalColumns: new[] { "AttendanceId", "ProcedureId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerRg = table.Column<float>(type: "real", nullable: false),
                    EmployerCpf = table.Column<float>(type: "real", nullable: false),
                    TipeId = table.Column<int>(type: "int", nullable: true),
                    AttendanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.EmployerId);
                    table.ForeignKey(
                        name: "FK_Employers_MyProperty_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "MyProperty",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employers_Tipes_TipeId",
                        column: x => x.TipeId,
                        principalTable: "Tipes",
                        principalColumn: "TipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployersAttendances",
                columns: table => new
                {
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployersAttendances", x => new { x.AttendanceId, x.EmployerId });
                    table.ForeignKey(
                        name: "FK_EmployersAttendances_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "EmployerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployersAttendances_MyProperty_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "MyProperty",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePeopleAttendance_PeoplesAttendancesAttendanceId_PeoplesAttendancesPeopleId",
                table: "AttendancePeopleAttendance",
                columns: new[] { "PeoplesAttendancesAttendanceId", "PeoplesAttendancesPeopleId" });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceProcedureAttendance_ProceduresAttendancesAttendanceId_ProceduresAttendancesProcedureId",
                table: "AttendanceProcedureAttendance",
                columns: new[] { "ProceduresAttendancesAttendanceId", "ProceduresAttendancesProcedureId" });

            migrationBuilder.CreateIndex(
                name: "IX_Employers_AttendanceId",
                table: "Employers",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_TipeId",
                table: "Employers",
                column: "TipeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployersAttendances_EmployerId",
                table: "EmployersAttendances",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_AttendanceId",
                table: "Peoples",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_PeopleAttendanceAttendanceId_PeopleAttendancePeopleId",
                table: "Peoples",
                columns: new[] { "PeopleAttendanceAttendanceId", "PeopleAttendancePeopleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_AttendanceId",
                table: "Procedures",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ProcedureAttendanceAttendanceId_ProcedureAttendanceProcedureId",
                table: "Procedures",
                columns: new[] { "ProcedureAttendanceAttendanceId", "ProcedureAttendanceProcedureId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendancePeopleAttendance");

            migrationBuilder.DropTable(
                name: "AttendanceProcedureAttendance");

            migrationBuilder.DropTable(
                name: "EmployersAttendances");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "PeoplesAttendances");

            migrationBuilder.DropTable(
                name: "ProceduresAttendances");

            migrationBuilder.DropTable(
                name: "MyProperty");

            migrationBuilder.DropTable(
                name: "Tipes");
        }
    }
}
