using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class v1272020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPatient",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblRegister",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRegister", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "tblProblem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problemDescription = table.Column<string>(nullable: false),
                    patientid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProblem", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblProblem_tblPatient_patientid",
                        column: x => x.patientid,
                        principalTable: "tblPatient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProblem_patientid",
                table: "tblProblem",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_tblRegister_Username",
                table: "tblRegister",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProblem");

            migrationBuilder.DropTable(
                name: "tblRegister");

            migrationBuilder.DropTable(
                name: "tblPatient");
        }
    }
}
