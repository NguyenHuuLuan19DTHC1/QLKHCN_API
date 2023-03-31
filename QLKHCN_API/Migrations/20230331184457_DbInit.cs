using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLKHCN_API.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataCSVs",
                columns: table => new
                {
                    number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    journal_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    issn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    eissn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_4 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_5 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_6 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    citations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    if_2022 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    jci = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    percentageOAGold = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCSVs", x => x.number);
                });

            migrationBuilder.CreateTable(
                name: "DataCSVTems",
                columns: table => new
                {
                    number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    journal_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    issn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    eissn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_4 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_5 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category_6 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    citations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    if_2022 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    jci = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    percentageOAGold = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    rank = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCSVTems", x => x.number);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    gmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    hoten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    socccd = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    chucvu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    chucdanh_hocvi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    gioitinh = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataCSVs");

            migrationBuilder.DropTable(
                name: "DataCSVTems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
