using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssesmentA.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produk",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama_barang = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    kode_barang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    jumlah_barang = table.Column<int>(type: "int", nullable: false),
                    tanggal = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produk", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produk");
        }
    }
}
