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
                    motive = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    personal_history = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    test_realized = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    treatment = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
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
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "DateTime", nullable: false),
                    img = table.Column<string>(type: "text", nullable: true),
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
                    { 1, "I love my work as a therapist, I feel privileged to work on what I have studied so much for. This gives me a fresh and committed style when it comes to serving you.I highly value a sense of humor, creativity and wit when it comes to intervening.", false, "28/04/2001", 987456, 12345678, "juangarcia@hotmail.com", "Postgraduate course in sexual diversity and human rights - Universidad Alas Peruanas", "Male", "https://bullseye-magazine.eu/wp-content/uploads/2019/09/portrait_test.jpg", "Juan Garcia", false, "123456789", 123456789, "Individual", "Esteem" },
                    { 2, "I am a happy and empathetic person. I enjoy meeting people from different cultures and discovering different ways of perceiving the world. I love listening to music and watching classic movies. I practice Yoga and Meditation in order to be more and more focused on the present moment.", false, "28/04/2001", 123456, 12344569, "anaflores@hotmail.com", "Bachelor of Psychology - Universidad Nacional Mayor de San Marcos", "Female", "https://www.enseignemoi-files.com/site/view/images/dyn-cache/pages/image/img/12/20/1427215436_122008_1200x667x0.jpg?v=2018021301", "Ana Flores", false, "ana123456", 987456123, "Individual", "Esteem" },
                    { 3, "I am a person who enjoys the therapeutic space. I constantly seek to update myself, preserving the essence of psychotherapy, thus generating a warm relationship of respect and empathy, with a vision of growth for my patients.", false, "17/04/1996", 123456, 72058669, "juanperez@hotmail.com", "Bachelor of Psychology - Technological University of Peru", "Male", "https://www.magisnet.com/wp-content/uploads/2021/04/Tal-BenShahar.jpg", "Juan Perez", false, "juan1234", 987489966, "Couple", "Depression" },
                    { 4, "Passionate about the social and human sciences that seek to understand the complexity of the human being, especially psychology and its various expressions. Lover of nature, plants, animals and my family. Any outdoor plan is always a good plan.", false, "18/11/1985", 123456, 12344569, "silvia.m@hotmail.com", "Bachelor of Psychology - Universidad Nacional Mayor de San Marcos", "Female", "https://img.freepik.com/foto-gratis/mujer-hermosa-joven-mirando-camara-chica-moda-verano-casual-camiseta-blanca-pantalones-cortos-hembra-positiva-muestra-emociones-faciales-modelo-divertido-aislado-amarillo_158538-15796.jpg?size=626&ext=jpg", "Silvia Muñoz", false, "sil123456", 987456123, "Couple", "Codependency" }
                });

            migrationBuilder.InsertData(
                table: "schedules",
                columns: new[] { "id", "time" },
                values: new object[,]
                {
                    { 1, "8:00" },
                    { 2, "9:00" },
                    { 3, "10:00" },
                    { 4, "11:00" },
                    { 5, "12:00" },
                    { 6, "16:00" },
                    { 7, "17:00" },
                    { 8, "18:00" },
                    { 9, "19:00" },
                    { 10, "20:00" }
                });

            migrationBuilder.InsertData(
                table: "publications",
                columns: new[] { "id", "created_at", "description", "img", "psychologist_id", "title" },
                values: new object[] { 1, new DateTime(2021, 10, 31, 22, 49, 49, 450, DateTimeKind.Local), "Anxiety is a mental problem that affects the health of many people. Anxiety is a feeling of fear, fear, and restlessness. It can make you sweat, feel restless and tense, and have palpitations. It can be a normal reaction to stress. For example, you may feel anxious when faced with a difficult problem at work, before taking an exam, or before making an important decision.", "https://estaticos.muyinteresante.es/media/cache/1140x_thumb/uploads/images/article/5e6b7bc55bafe86b2ccdb361/ansiedad-corona_0.jpg", 1, "How to beat anxiety?" });

            migrationBuilder.InsertData(
                table: "publications",
                columns: new[] { "id", "created_at", "description", "img", "psychologist_id", "title" },
                values: new object[] { 2, new DateTime(2021, 10, 31, 22, 49, 49, 450, DateTimeKind.Local), "Depression is one of the most difficult mental problems to treat. That is why in this chapter we will teach you how to support a person who has symptoms of depression.", "https://assets.weforum.org/article/image/responsive_large_E79PmG1Oop_9P7-edBkH9JddpXUpnaVEz2cvg8KkYOE.jpg", 2, "How to help a person with depression?" });

            migrationBuilder.InsertData(
                table: "publications",
                columns: new[] { "id", "created_at", "description", "img", "psychologist_id", "title" },
                values: new object[] { 3, new DateTime(2021, 10, 31, 22, 49, 49, 450, DateTimeKind.Local), "We can all recognize those emotions that we like, pleasant emotions. Who doesn't like to feel happy, excited, in love, etc. But on the other hand, we also recognize emotions that can be more uncomfortable, for example, sadness, shame, guilt and anger.", "https://gentequebrilla.azurewebsites.net/wp-content/uploads/2019/04/12014-1024x604.jpg", 2, "Learning about negative emotions" });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "publication_id", "text" },
                values: new object[,]
                {
                    { 1, 1, "#anxiety" },
                    { 2, 1, "#fear" },
                    { 3, 2, "#depression" },
                    { 4, 2, "#sadness" },
                    { 5, 3, "#emotions" },
                    { 6, 3, "#negativity" }
                });

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
