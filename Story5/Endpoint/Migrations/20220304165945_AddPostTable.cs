using Microsoft.EntityFrameworkCore.Migrations;

namespace Endpoint.Migrations
{
    public partial class AddPostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "CSVRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    TotalAmount = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CSVRecords_PostId",
                table: "CSVRecords",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_CSVRecords_Posts_PostId",
                table: "CSVRecords",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CSVRecords_Posts_PostId",
                table: "CSVRecords");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_CSVRecords_PostId",
                table: "CSVRecords");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "CSVRecords");
        }
    }
}
