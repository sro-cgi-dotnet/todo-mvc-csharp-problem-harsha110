using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_core.Migrations
{
    public partial class Createmain_noted1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Plaintext = table.Column<string>(nullable: true),
                    Pinned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.NoteId);
                });

            migrationBuilder.CreateTable(
                name: "Ch1",
                columns: table => new
                {
                    checklist_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Checklists = table.Column<string>(nullable: true),
                    NoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ch1", x => x.checklist_Id);
                    table.ForeignKey(
                        name: "FK_Ch1_Students_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Students",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "L1",
                columns: table => new
                {
                    Label_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true),
                    NoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_L1", x => x.Label_Id);
                    table.ForeignKey(
                        name: "FK_L1_Students_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Students",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ch1_NoteId",
                table: "Ch1",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_L1_NoteId",
                table: "L1",
                column: "NoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ch1");

            migrationBuilder.DropTable(
                name: "L1");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
