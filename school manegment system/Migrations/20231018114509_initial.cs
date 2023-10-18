using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_manegment_system.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminlogin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminlogin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "school",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parent_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classs = table.Column<int>(type: "int", nullable: false),
                    progress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    class_teachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentpasskey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roll_no = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teacherslogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherslogins", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminlogin");

            migrationBuilder.DropTable(
                name: "school");

            migrationBuilder.DropTable(
                name: "teacherslogins");
        }
    }
}
