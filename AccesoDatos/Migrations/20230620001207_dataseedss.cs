using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    public partial class dataseedss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cliente_IdCliente",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                table: "Usuario");

            migrationBuilder.InsertData(
                table: "App",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "App Users Management" },
                    { 2, "SAIGNa Web" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Solumaxt Eirl." },
                    { 2, "SG Hidrocarburos" }
                });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administración del sistema" },
                    { 2, "Gestión comercial" },
                    { 3, "Construcción Internas" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Soporte" },
                    { 2, "Administrador" },
                    { 3, "Vendedor" },
                    { 4, "Coordinado de ventas" }
                });

            migrationBuilder.InsertData(
                table: "Operaciones",
                columns: new[] { "Id", "IdMod", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Creación de usuarios" },
                    { 2, 1, "Actualización de usuarios" },
                    { 3, 2, "Consultar todas las ventas" },
                    { 4, 2, "Creación de contratos" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "FechaVencimiento", "IdCliente", "IdRol", "ImagenPerfil", "Nombre", "Password" },
                values: new object[,]
                {
                    { 1, "dani@gmail.com", new DateTime(2023, 6, 19, 19, 12, 6, 556, DateTimeKind.Local).AddTicks(9465), 1, 1, null, "Daniel Perez", null },
                    { 2, "jhon@gmail.com", new DateTime(2023, 6, 19, 19, 12, 6, 556, DateTimeKind.Local).AddTicks(9476), 1, 1, null, "Jhon Chonta", null },
                    { 3, "marco@gmail.com", new DateTime(2023, 6, 19, 19, 12, 6, 556, DateTimeKind.Local).AddTicks(9477), 2, 3, null, "Marco Tarmeño", null },
                    { 4, "abi@gmail.com", new DateTime(2023, 6, 19, 19, 12, 6, 556, DateTimeKind.Local).AddTicks(9478), 2, 4, null, "Abigail Garcia", null }
                });

            migrationBuilder.InsertData(
                table: "RolOpe",
                columns: new[] { "Id", "IdOpe", "IdRol" },
                values: new object[,]
                {
                    { 1, 2, 2 },
                    { 2, 3, 2 },
                    { 3, 4, 2 },
                    { 4, 4, 3 },
                    { 5, 3, 4 },
                    { 6, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "UsuApp",
                columns: new[] { "Id", "IdApp", "IdUsu" },
                values: new object[,]
                {
                    { 1, 2, 3 },
                    { 2, 2, 4 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cliente_IdCliente",
                table: "Usuario",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                table: "Usuario",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cliente_IdCliente",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                table: "Usuario");

            migrationBuilder.DeleteData(
                table: "App",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolOpe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolOpe",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolOpe",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RolOpe",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RolOpe",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RolOpe",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UsuApp",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UsuApp",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "App",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Operaciones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cliente_IdCliente",
                table: "Usuario",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_IdRol",
                table: "Usuario",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
