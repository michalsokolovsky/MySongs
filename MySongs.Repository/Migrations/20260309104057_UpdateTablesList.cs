using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySongs.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablesList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_UserId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Songs_SongId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Artists_UserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Songs_SongId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "ListeningHistorys");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Recommendations");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_UserId",
                table: "ListeningHistorys",
                newName: "IX_ListeningHistorys_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_SongId",
                table: "ListeningHistorys",
                newName: "IX_ListeningHistorys_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_UserId",
                table: "Recommendations",
                newName: "IX_Recommendations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_SongId",
                table: "Recommendations",
                newName: "IX_Recommendations_SongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListeningHistorys",
                table: "ListeningHistorys",
                column: "HistoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations",
                column: "RecommendationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListeningHistorys_Songs_SongId",
                table: "ListeningHistorys",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListeningHistorys_Users_UserId",
                table: "ListeningHistorys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Songs_SongId",
                table: "Recommendations",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Users_UserId",
                table: "Recommendations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListeningHistorys_Songs_SongId",
                table: "ListeningHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_ListeningHistorys_Users_UserId",
                table: "ListeningHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Songs_SongId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Users_UserId",
                table: "Recommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListeningHistorys",
                table: "ListeningHistorys");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Artists");

            migrationBuilder.RenameTable(
                name: "Recommendations",
                newName: "Albums");

            migrationBuilder.RenameTable(
                name: "ListeningHistorys",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_UserId",
                table: "Albums",
                newName: "IX_Albums_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_SongId",
                table: "Albums",
                newName: "IX_Albums_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_ListeningHistorys_UserId",
                table: "Categories",
                newName: "IX_Categories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ListeningHistorys_SongId",
                table: "Categories",
                newName: "IX_Categories_SongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "RecommendationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_UserId",
                table: "Albums",
                column: "UserId",
                principalTable: "Artists",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Songs_SongId",
                table: "Albums",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Artists_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "Artists",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Songs_SongId",
                table: "Categories",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
