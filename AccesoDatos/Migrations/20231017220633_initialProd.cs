using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    public partial class initialProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(50)", nullable: true),
                    ImagenApp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ContainerDeAdjuntos = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    IdMod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operaciones_Modulo_IdMod",
                        column: x => x.IdMod,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImagenPerfil = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolOpe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdOpe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolOpe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolOpe_Operaciones_IdOpe",
                        column: x => x.IdOpe,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolOpe_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsu = table.Column<int>(type: "int", nullable: false),
                    IdApp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuApp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuApp_App_IdApp",
                        column: x => x.IdApp,
                        principalTable: "App",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuApp_Usuario_IdUsu",
                        column: x => x.IdUsu,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "App",
                columns: new[] { "Id", "ContainerDeAdjuntos", "Descripcion", "ImagenApp", "Nombre" },
                values: new object[,]
                {
                    { 1, "f000solu01", "Administración de usuarios", "000_app_admin_user.jpg", "App Users Management" },
                    { 2, "f000solu01", "Sistema de red local.", "000_app_SAIGNa_Local_Icono.ico", "SAIGNa Local" },
                    { 3, "f000solu01", "Sistema web para instalaciones de gas.", "000_app_logoTmp_Solumas.png", "SAIGNa Web - Solu" },
                    { 4, "f001sghi01", "Sistema web para instalaciones de gas", "000_app_logoTmp_Solumas.png", "SAIGNa Web - Hidrocarburos" }
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
                    { 1, "dani@gmail.com", new DateTime(2023, 10, 17, 17, 6, 33, 322, DateTimeKind.Local).AddTicks(3554), 1, 1, null, "Daniel Perez", "123456" },
                    { 2, "jhon@gmail.com", new DateTime(2023, 10, 17, 17, 6, 33, 322, DateTimeKind.Local).AddTicks(3564), 1, 1, null, "Jhon Chonta", "123456" },
                    { 3, "marco@gmail.com", new DateTime(2023, 10, 17, 17, 6, 33, 322, DateTimeKind.Local).AddTicks(3565), 2, 3, null, "Marco Tarmeño", "123456" },
                    { 4, "abi@gmail.com", new DateTime(2023, 10, 17, 17, 6, 33, 322, DateTimeKind.Local).AddTicks(3566), 2, 4, null, "Abigail Garcia", "123456" }
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
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Nombre",
                table: "App",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_IdMod",
                table: "Operaciones",
                column: "IdMod");

            migrationBuilder.CreateIndex(
                name: "IX_RolOpe_IdOpe",
                table: "RolOpe",
                column: "IdOpe");

            migrationBuilder.CreateIndex(
                name: "IX_RolOpe_IdRol",
                table: "RolOpe",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_UsuApp_IdApp",
                table: "UsuApp",
                column: "IdApp");

            migrationBuilder.CreateIndex(
                name: "IX_UsuApp_IdUsu",
                table: "UsuApp",
                column: "IdUsu");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdCliente",
                table: "Usuario",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario",
                column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolOpe");

            migrationBuilder.DropTable(
                name: "UsuApp");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "App");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
