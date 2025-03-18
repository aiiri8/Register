using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Register.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "electronic_devices");

            migrationBuilder.DropTable(
                name: "electronic_devices_categories");

            migrationBuilder.DropTable(
                name: "recycling_application_items");

            migrationBuilder.DropTable(
                name: "recycling_application_statuses");

            migrationBuilder.DropTable(
                name: "recycling_applications");

            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bank_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "calculation_methods",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    calculation_method_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calculation_methods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "document_types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_type_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "guardians",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    patronymic = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    sex_id = table.Column<int>(type: "integer", nullable: false),
                    inn = table.Column<string>(type: "text", nullable: false),
                    snils = table.Column<string>(type: "text", nullable: false),
                    document_type_id = table.Column<int>(type: "integer", nullable: false),
                    document_series = table.Column<string>(type: "text", nullable: false),
                    document_number = table.Column<string>(type: "text", nullable: false),
                    bank_id = table.Column<int>(type: "integer", nullable: false),
                    recipient_account = table.Column<string>(type: "text", nullable: false),
                    opening_date = table.Column<DateOnly>(type: "date", nullable: false),
                    issuing_authority_id = table.Column<int>(type: "integer", nullable: false),
                    issuing_date = table.Column<DateOnly>(type: "date", nullable: false),
                    beginning_date = table.Column<DateOnly>(type: "date", nullable: false),
                    ending_date = table.Column<DateOnly>(type: "date", nullable: false),
                    territory_id = table.Column<int>(type: "integer", nullable: false),
                    calculation_method_id = table.Column<int>(type: "integer", nullable: false),
                    pension_status_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guardians", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "issuing_authorities",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    issuing_authority_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issuing_authorities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pension_statuses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pension_status_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pension_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "relationships",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guardian_id = table.Column<long>(type: "bigint", nullable: false),
                    ward_id = table.Column<long>(type: "bigint", nullable: false),
                    days_in_month = table.Column<int>(type: "integer", nullable: false),
                    ending_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relationships", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sexes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sex_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sexes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "territories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    territory_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_territories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "wardens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    patronymic = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    snils = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wardens", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banks");

            migrationBuilder.DropTable(
                name: "calculation_methods");

            migrationBuilder.DropTable(
                name: "document_types");

            migrationBuilder.DropTable(
                name: "guardians");

            migrationBuilder.DropTable(
                name: "issuing_authorities");

            migrationBuilder.DropTable(
                name: "pension_statuses");

            migrationBuilder.DropTable(
                name: "relationships");

            migrationBuilder.DropTable(
                name: "sexes");

            migrationBuilder.DropTable(
                name: "territories");

            migrationBuilder.DropTable(
                name: "wardens");

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recycling_application_item_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    sent_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    test = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "electronic_devices",
                columns: table => new
                {
                    electronic_device_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    electronic_device_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_electronic_devices", x => x.electronic_device_id);
                });

            migrationBuilder.CreateTable(
                name: "electronic_devices_categories",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_electronic_devices_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recycling_application_items",
                columns: table => new
                {
                    recycling_application_item_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    electronic_device_id = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    recycling_application_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recycling_application_items", x => x.recycling_application_item_id);
                });

            migrationBuilder.CreateTable(
                name: "recycling_application_statuses",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recycling_application_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recycling_applications",
                columns: table => new
                {
                    recycling_application_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    closed_at_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: true),
                    status_id = table.Column<short>(type: "smallint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recycling_applications", x => x.recycling_application_id);
                });
        }
    }
}
