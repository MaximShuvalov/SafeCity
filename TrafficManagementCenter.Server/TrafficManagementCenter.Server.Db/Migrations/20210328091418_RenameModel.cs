using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TrafficManagementCenter.Server.Db.Migrations
{
    public partial class RenameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassAppeal",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAppeal", x => x.Key);
                });

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
                    ClassAppealId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Attachment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appeal", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Appeal_ClassAppeal_ClassAppealId",
                        column: x => x.ClassAppealId,
                        principalTable: "ClassAppeal",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appeal_SubtypeAppeals_SubtypeId",
                        column: x => x.SubtypeId,
                        principalTable: "SubtypeAppeals",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appeal_ClassAppealId",
                table: "Appeal",
                column: "ClassAppealId");

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
                name: "ClassAppeal");

            migrationBuilder.DropTable(
                name: "SubtypeAppeals");

            migrationBuilder.DropTable(
                name: "TypeAppeal");
        }
    }
}
