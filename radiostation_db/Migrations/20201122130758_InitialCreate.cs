using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace radiostation_db.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Должности",
                columns: table => new
                {
                    код_должности = table.Column<byte[]>(type: "INT", nullable: false),
                    наименование_должности = table.Column<string>(type: "INT", nullable: false),
                    оклад = table.Column<int>(type: "INT", nullable: false),
                    обязанности = table.Column<string>(type: "INT", nullable: false),
                    требования = table.Column<string>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Должности", x => x.код_должности);
                });

            migrationBuilder.CreateTable(
                name: "Жанры",
                columns: table => new
                {
                    код_жанра = table.Column<byte[]>(type: "INT", nullable: false),
                    наименование = table.Column<string>(type: "INT", nullable: false),
                    описание = table.Column<string>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Жанры", x => x.код_жанра);
                });

            migrationBuilder.CreateTable(
                name: "Исполнители",
                columns: table => new
                {
                    код_исполнителя = table.Column<byte[]>(type: "INT", nullable: false),
                    наименование = table.Column<string>(type: "INT", nullable: false),
                    описание = table.Column<string>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Исполнители", x => x.код_исполнителя);
                });

            migrationBuilder.CreateTable(
                name: "Сотрудники",
                columns: table => new
                {
                    код_сотрудника = table.Column<byte[]>(type: "INT", nullable: false),
                    ФИО = table.Column<string>(type: "INT", nullable: false),
                    Возраст = table.Column<int>(type: "INT", nullable: false),
                    пол = table.Column<string>(type: "INT", nullable: false),
                    телефон = table.Column<int>(type: "INT", nullable: false),
                    адрес = table.Column<string>(type: "INT", nullable: false),
                    паспортные_данны = table.Column<string>(type: "INT", nullable: false),
                    код_должности = table.Column<byte[]>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сотрудники", x => x.код_сотрудника);
                    table.ForeignKey(
                        name: "FK_Сотрудники_Должности_код_должности",
                        column: x => x.код_должности,
                        principalTable: "Должности",
                        principalColumn: "код_должности",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Записи",
                columns: table => new
                {
                    код_записи = table.Column<byte[]>(type: "INT", nullable: false),
                    год = table.Column<DateTime>(type: "INT", nullable: false),
                    альбом = table.Column<string>(type: "INT", nullable: false),
                    рейтинг = table.Column<int>(type: "INT", nullable: false),
                    дата_записи = table.Column<DateTime>(type: "INT", nullable: false),
                    длительность = table.Column<string>(type: "INT", nullable: false),
                    наименование = table.Column<string>(type: "INT", nullable: false),
                    код_исполнителя = table.Column<byte[]>(type: "INT", nullable: false),
                    код_жанра = table.Column<byte[]>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Записи", x => x.код_записи);
                    table.ForeignKey(
                        name: "FK_Записи_Жанры_код_жанра",
                        column: x => x.код_жанра,
                        principalTable: "Жанры",
                        principalColumn: "код_жанра",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Записи_Исполнители_код_исполнителя",
                        column: x => x.код_исполнителя,
                        principalTable: "Исполнители",
                        principalColumn: "код_исполнителя",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "График_работы",
                columns: table => new
                {
                    дата = table.Column<DateTime>(type: "INT", nullable: false),
                    время_ = table.Column<int>(type: "INT", nullable: false),
                    код_сотрудника = table.Column<byte[]>(type: "INT", nullable: false),
                    код_записи = table.Column<byte[]>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_График_работы_Записи_код_записи",
                        column: x => x.код_записи,
                        principalTable: "Записи",
                        principalColumn: "код_записи",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_График_работы_Сотрудники_код_сотрудника",
                        column: x => x.код_сотрудника,
                        principalTable: "Сотрудники",
                        principalColumn: "код_сотрудника",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_График_работы_код_записи",
                table: "График_работы",
                column: "код_записи");

            migrationBuilder.CreateIndex(
                name: "IX_График_работы_код_сотрудника",
                table: "График_работы",
                column: "код_сотрудника");

            migrationBuilder.CreateIndex(
                name: "IX_Жанры_описание",
                table: "Жанры",
                column: "описание",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Записи_код_жанра",
                table: "Записи",
                column: "код_жанра");

            migrationBuilder.CreateIndex(
                name: "IX_Записи_код_исполнителя",
                table: "Записи",
                column: "код_исполнителя");

            migrationBuilder.CreateIndex(
                name: "IX_Записи_наименование",
                table: "Записи",
                column: "наименование",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Исполнители_описание",
                table: "Исполнители",
                column: "описание",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_адрес",
                table: "Сотрудники",
                column: "адрес",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_код_должности",
                table: "Сотрудники",
                column: "код_должности");

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_паспортные_данны",
                table: "Сотрудники",
                column: "паспортные_данны",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_телефон",
                table: "Сотрудники",
                column: "телефон",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "График_работы");

            migrationBuilder.DropTable(
                name: "Записи");

            migrationBuilder.DropTable(
                name: "Сотрудники");

            migrationBuilder.DropTable(
                name: "Жанры");

            migrationBuilder.DropTable(
                name: "Исполнители");

            migrationBuilder.DropTable(
                name: "Должности");
        }
    }
}
