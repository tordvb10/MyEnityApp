using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEnityApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MyEntities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MyEntities");
        }
    }
}
