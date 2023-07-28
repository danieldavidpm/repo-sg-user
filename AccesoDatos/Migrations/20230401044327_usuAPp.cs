using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    public partial class usuAPp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuApp_App_appId",
                table: "UsuApp");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuApp_Usuario_usuarioId",
                table: "UsuApp");

            migrationBuilder.DropIndex(
                name: "IX_UsuApp_appId",
                table: "UsuApp");

            migrationBuilder.DropIndex(
                name: "IX_UsuApp_usuarioId",
                table: "UsuApp");

            migrationBuilder.DropColumn(
                name: "appId",
                table: "UsuApp");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "UsuApp");

            migrationBuilder.CreateIndex(
                name: "IX_UsuApp_IdApp",
                table: "UsuApp",
                column: "IdApp");

            migrationBuilder.CreateIndex(
                name: "IX_UsuApp_IdUsu",
                table: "UsuApp",
                column: "IdUsu");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuApp_App_IdApp",
                table: "UsuApp",
                column: "IdApp",
                principalTable: "App",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuApp_Usuario_IdUsu",
                table: "UsuApp",
                column: "IdUsu",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuApp_App_IdApp",
                table: "UsuApp");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuApp_Usuario_IdUsu",
                table: "UsuApp");

            migrationBuilder.DropIndex(
                name: "IX_UsuApp_IdApp",
                table: "UsuApp");

            migrationBuilder.DropIndex(
                name: "IX_UsuApp_IdUsu",
                table: "UsuApp");

            migrationBuilder.AddColumn<int>(
                name: "appId",
                table: "UsuApp",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "UsuApp",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuApp_appId",
                table: "UsuApp",
                column: "appId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuApp_usuarioId",
                table: "UsuApp",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuApp_App_appId",
                table: "UsuApp",
                column: "appId",
                principalTable: "App",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuApp_Usuario_usuarioId",
                table: "UsuApp",
                column: "usuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
