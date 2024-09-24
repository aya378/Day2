using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ins_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    Dept_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_Dept_id",
                        column: x => x.Dept_id,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: true),
                    leader_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Students_Students_leader_id",
                        column: x => x.leader_id,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ins_Courses",
                columns: table => new
                {
                    ins_id = table.Column<int>(type: "int", nullable: false),
                    crs_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ins_Courses", x => new { x.ins_id, x.crs_id });
                    table.ForeignKey(
                        name: "FK_Ins_Courses_Courses_crs_id",
                        column: x => x.crs_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ins_Courses_Instructors_ins_id",
                        column: x => x.ins_id,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Std_Crs",
                columns: table => new
                {
                    st_id = table.Column<int>(type: "int", nullable: false),
                    crs_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Std_Crs", x => new { x.st_id, x.crs_id });
                    table.ForeignKey(
                        name: "FK_Std_Crs_Courses_crs_id",
                        column: x => x.crs_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Std_Crs_Students_st_id",
                        column: x => x.st_id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ins_id",
                table: "Departments",
                column: "ins_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Courses_crs_id",
                table: "Ins_Courses",
                column: "crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Dept_id",
                table: "Instructors",
                column: "Dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Std_Crs_crs_id",
                table: "Std_Crs",
                column: "crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_dept_id",
                table: "Students",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_leader_id",
                table: "Students",
                column: "leader_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_ins_id",
                table: "Departments",
                column: "ins_id",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_ins_id",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Ins_Courses");

            migrationBuilder.DropTable(
                name: "Std_Crs");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
