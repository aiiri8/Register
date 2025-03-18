using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "days_in_month",
                table: "relationships",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "days_in_month",
                table: "relationships",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
