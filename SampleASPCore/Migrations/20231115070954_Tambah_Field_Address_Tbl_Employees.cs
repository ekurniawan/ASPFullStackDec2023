using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleASPCore.Migrations
{
    /// <inheritdoc />
    public partial class Tambah_Field_Address_Tbl_Employees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employees");
        }
    }
}
