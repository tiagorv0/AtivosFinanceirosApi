using Microsoft.EntityFrameworkCore.Migrations;

namespace AtivosFinanceiros.Infra.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "VARCHAR(6)", maxLength: 6, nullable: false),
                    NomeDaEmpresa = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Setor = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FIIs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "VARCHAR(6)", maxLength: 6, nullable: false),
                    NomeDaEmpresa = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Setor = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIIs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acoes");

            migrationBuilder.DropTable(
                name: "FIIs");
        }
    }
}
