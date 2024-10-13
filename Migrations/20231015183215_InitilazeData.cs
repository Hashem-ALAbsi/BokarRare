using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BokarRare.Migrations
{
    public partial class InitilazeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BR");

            migrationBuilder.CreateTable(
                name: "Curses",
                schema: "BR",
                columns: table => new
                {
                    CurseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurseName = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curses", x => x.CurseId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                schema: "BR",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "TypeUsers",
                schema: "BR",
                columns: table => new
                {
                    TypeUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeUserName = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUsers", x => x.TypeUserId);
                });

            migrationBuilder.CreateTable(
                name: "Techares",
                schema: "BR",
                columns: table => new
                {
                    TechId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurseId = table.Column<int>(type: "int", nullable: false),
                    TechSal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TechImage = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techares", x => x.TechId);
                    table.ForeignKey(
                        name: "FK_Techares_Curses_CurseId",
                        column: x => x.CurseId,
                        principalSchema: "BR",
                        principalTable: "Curses",
                        principalColumn: "CurseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "BR",
                columns: table => new
                {
                    StuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StuName = table.Column<string>(type: "varchar(250)", nullable: false),
                    StuPhone = table.Column<string>(type: "varchar(250)", nullable: false),
                    StuAddress = table.Column<string>(type: "varchar(250)", nullable: false),
                    StuBirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurseId = table.Column<int>(type: "int", nullable: false),
                    StuTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StuImage = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StuId);
                    table.ForeignKey(
                        name: "FK_Students_Curses_CurseId",
                        column: x => x.CurseId,
                        principalSchema: "BR",
                        principalTable: "Curses",
                        principalColumn: "CurseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Types_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "BR",
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "BR",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassowrd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_TypeUsers_TypeUserId",
                        column: x => x.TypeUserId,
                        principalSchema: "BR",
                        principalTable: "TypeUsers",
                        principalColumn: "TypeUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dagree",
                schema: "BR",
                columns: table => new
                {
                    DagreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StuId = table.Column<int>(type: "int", nullable: false),
                    StuHW = table.Column<int>(type: "int", nullable: false),
                    MideXame = table.Column<int>(type: "int", nullable: false),
                    FinalXame = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Etamate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dagree", x => x.DagreeId);
                    table.ForeignKey(
                        name: "FK_Dagree_Students_StuId",
                        column: x => x.StuId,
                        principalSchema: "BR",
                        principalTable: "Students",
                        principalColumn: "StuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dagree_StuId",
                schema: "BR",
                table: "Dagree",
                column: "StuId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurseId",
                schema: "BR",
                table: "Students",
                column: "CurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TypeId",
                schema: "BR",
                table: "Students",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Techares_CurseId",
                schema: "BR",
                table: "Techares",
                column: "CurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeUserId",
                schema: "BR",
                table: "Users",
                column: "TypeUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dagree",
                schema: "BR");

            migrationBuilder.DropTable(
                name: "Techares",
                schema: "BR");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "BR");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "BR");

            migrationBuilder.DropTable(
                name: "TypeUsers",
                schema: "BR");

            migrationBuilder.DropTable(
                name: "Curses",
                schema: "BR");

            migrationBuilder.DropTable(
                name: "Types",
                schema: "BR");
        }
    }
}
