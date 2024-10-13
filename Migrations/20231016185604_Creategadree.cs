using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BokarRare.Migrations
{
    public partial class Creategadree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbgads",
                schema: "BR",
                columns: table => new
                {
                    TDagrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StuyId = table.Column<int>(type: "int", nullable: false),
                    StuHW = table.Column<int>(type: "int", nullable: false),
                    MideXame = table.Column<int>(type: "int", nullable: false),
                    FinalXame = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etamate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbgads", x => x.TDagrId);
                    table.ForeignKey(
                        name: "FK_Tbgads_Studenty_StuyId",
                        column: x => x.StuyId,
                        principalSchema: "BR",
                        principalTable: "Studenty",
                        principalColumn: "StuyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbgads_StuyId",
                schema: "BR",
                table: "Tbgads",
                column: "StuyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbgads",
                schema: "BR");
        }
    }
}
