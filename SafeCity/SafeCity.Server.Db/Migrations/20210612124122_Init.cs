using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SafeCity.Server.Db.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeAppeal",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAppeal", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "SubtypeAppeals",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    TypesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtypeAppeals", x => x.Key);
                    table.ForeignKey(
                        name: "FK_SubtypeAppeals_TypeAppeal_TypesId",
                        column: x => x.TypesId,
                        principalTable: "TypeAppeal",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appeal",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubtypeId = table.Column<long>(type: "bigint", nullable: false),
                    AppealTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Attachment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appeal", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Appeal_SubtypeAppeals_SubtypeId",
                        column: x => x.SubtypeId,
                        principalTable: "SubtypeAppeals",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appeal_TypeAppeal_AppealTypeId",
                        column: x => x.AppealTypeId,
                        principalTable: "TypeAppeal",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypeAppeal",
                columns: new[] { "Key", "Name", "Note" },
                values: new object[,]
                {
                    { 1L, "Безопасность на дорогах", null },
                    { 2L, "Комфортное проживание", null }
                });

            migrationBuilder.InsertData(
                table: "SubtypeAppeals",
                columns: new[] { "Key", "Name", "Note", "TypesId" },
                values: new object[,]
                {
                    { 1L, "Качество автомобильных дорог", null, 1L },
                    { 2L, "Наличие/качество пешеходных переходов", null, 1L },
                    { 3L, "Наличие/качество освещения", null, 1L },
                    { 4L, "Безопасная дорога в школу для детей", null, 1L },
                    { 5L, "Отсутствие/качество тротуаров", null, 2L },
                    { 6L, "Отсутствие /качество ливневой канализации", null, 2L },
                    { 7L, "Заброшенные объекты строительства / здания", null, 2L },
                    { 8L, "Отсутствие /качество детских площадок", null, 2L },
                    { 9L, "Проблемы при проведении капитального ремонта", null, 2L },
                    { 10L, "Стихийные свалки", null, 2L },
                    { 11L, "Отсутствие /качество инфраструктуры для передвижения людей с ограниченными возможностями", null, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appeal_AppealTypeId",
                table: "Appeal",
                column: "AppealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appeal_SubtypeId",
                table: "Appeal",
                column: "SubtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtypeAppeals_TypesId",
                table: "SubtypeAppeals",
                column: "TypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appeal");

            migrationBuilder.DropTable(
                name: "SubtypeAppeals");

            migrationBuilder.DropTable(
                name: "TypeAppeal");
        }
    }
}
