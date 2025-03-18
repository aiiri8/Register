using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "issuing_authorities",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "issuing_authorities");
        }
    }
}
