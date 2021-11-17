using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PsychoHelp_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    last_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    phone = table.Column<long>(type: "bigint", maxLength: 9, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    img = table.Column<string>(type: "text", nullable: true),
                    log_book_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_patient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "psychologists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    age = table.Column<string>(type: "text", nullable: false),
                    dni = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    specialization = table.Column<string>(type: "text", nullable: false),
                    formation = table.Column<string>(type: "text", nullable: false),
                    about = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    @new = table.Column<bool>(name: "new", type: "tinyint(1)", nullable: false),
                    img = table.Column<string>(type: "text", nullable: false),
                    cmp = table.Column<int>(type: "int", nullable: false),
                    genre = table.Column<string>(type: "text", nullable: false),
                    session_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_psychologists", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    time = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_schedules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "log_book",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    log_book_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    public_history = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    consultation_reason = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_log_book", x => x.id);
                    table.ForeignKey(
                        name: "f_k_log_book__patient_id",
                        column: x => x.id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    psycho_notes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    schedule_date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    psycho_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_appointments", x => x.id);
                    table.ForeignKey(
                        name: "k_appointment_patient",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "k_appointment_psycho",
                        column: x => x.psycho_id,
                        principalTable: "psychologists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "publications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "DateTime", nullable: false),
                    psychologist_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_publications", x => x.id);
                    table.ForeignKey(
                        name: "f_k_publications_psychologists_psychologist_id",
                        column: x => x.psychologist_id,
                        principalTable: "psychologists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "psychologist_schedule",
                columns: table => new
                {
                    psychologists_id = table.Column<int>(type: "int", nullable: false),
                    schedules_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_psychologist_schedule", x => new { x.psychologists_id, x.schedules_id });
                    table.ForeignKey(
                        name: "f_k_psychologist_schedule_psychologists_psychologists_id",
                        column: x => x.psychologists_id,
                        principalTable: "psychologists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "f_k_psychologist_schedule_schedules_schedules_id",
                        column: x => x.schedules_id,
                        principalTable: "schedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    publication_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_tags", x => x.id);
                    table.ForeignKey(
                        name: "f_k_tags_publications_publication_id",
                        column: x => x.publication_id,
                        principalTable: "publications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "psychologists",
                columns: new[] { "id", "about", "active", "age", "cmp", "dni", "email", "formation", "genre", "img", "name", "new", "password", "phone", "session_type", "specialization" },
                values: new object[,]
                {
                    { 1, "qwertyuiop", false, "28/04/2001", 987456, 12345678, "usuarios1@hotmail.com", "UPC", "Male", "sadsdasda", "Juan Garcia", false, "123456789", 123456789, "Individual", "autoestima" },
                    { 2, "qwertyuiop", false, "28/04/2001", 123456, 12344569, "usuarios2@hotmail.com", "UPC", "Male", "sadsdasda", "Ana Flores", false, "123456", 987456123, "Individual", "autoestima" }
                });

            migrationBuilder.InsertData(
                table: "schedules",
                columns: new[] { "id", "time" },
                values: new object[,]
                {
                    { 1, "8:00" },
                    { 2, "9:00" },
                    { 3, "10:00" },
                    { 4, "11:00" }
                });

            migrationBuilder.InsertData(
                table: "publications",
                columns: new[] { "id", "created_at", "description", "psychologist_id", "title" },
                values: new object[] { 1, new DateTime(2021, 10, 31, 22, 49, 49, 450, DateTimeKind.Local), "Descripcion de Prueba", 1, "Prueba 1" });

            migrationBuilder.InsertData(
                table: "publications",
                columns: new[] { "id", "created_at", "description", "psychologist_id", "title" },
                values: new object[] { 2, new DateTime(2021, 10, 31, 22, 49, 49, 450, DateTimeKind.Local), "Descripcion de Prueba", 2, "Prueba 2" });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "publication_id", "text" },
                values: new object[] { 1, 1, "Tag Prueba 1" });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "publication_id", "text" },
                values: new object[] { 2, 1, "Tag Prueba 2" });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "publication_id", "text" },
                values: new object[] { 3, 2, "Tag Prueba 3" });

            migrationBuilder.CreateIndex(
                name: "i_x_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "i_x_appointments_psycho_id",
                table: "appointments",
                column: "psycho_id");

            migrationBuilder.CreateIndex(
                name: "i_x_psychologist_schedule_schedules_id",
                table: "psychologist_schedule",
                column: "schedules_id");

            migrationBuilder.CreateIndex(
                name: "i_x_publications_psychologist_id",
                table: "publications",
                column: "psychologist_id");

            migrationBuilder.CreateIndex(
                name: "i_x_tags_publication_id",
                table: "tags",
                column: "publication_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "log_book");

            migrationBuilder.DropTable(
                name: "psychologist_schedule");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "publications");

            migrationBuilder.DropTable(
                name: "psychologists");
        }
    }
}
