using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grace_Project.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BepulKurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QushilganlarSoni = table.Column<int>(type: "int", nullable: false),
                    VideoSoni = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BepulKurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OchniyKurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QushilganlarSoni = table.Column<int>(type: "int", nullable: false),
                    Narxi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VideoSoni = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OchniyKurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnlaynKurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QushilganlarSoni = table.Column<int>(type: "int", nullable: false),
                    Narxi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VideoSoni = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlaynKurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnlaynKursId = table.Column<int>(type: "int", nullable: false),
                    OnlaynKurs = table.Column<bool>(type: "bit", nullable: false),
                    OchniyKurs = table.Column<bool>(type: "bit", nullable: false),
                    BepulKurs = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BepulKurs");

            migrationBuilder.DropTable(
                name: "OchniyKurs");

            migrationBuilder.DropTable(
                name: "OnlaynKurs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
