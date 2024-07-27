using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryTask.Migrations
{
    /// <inheritdoc />
    public partial class initiala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_BookAuthorNavigationId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_BookGenreNavigationId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookAuthorNavigationId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookGenreNavigationId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookAuthorNavigationId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookGenreNavigationId",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookAuthorNavigationId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookGenreNavigationId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookAuthorNavigationId",
                table: "Books",
                column: "BookAuthorNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookGenreNavigationId",
                table: "Books",
                column: "BookGenreNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_BookAuthorNavigationId",
                table: "Books",
                column: "BookAuthorNavigationId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_BookGenreNavigationId",
                table: "Books",
                column: "BookGenreNavigationId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
