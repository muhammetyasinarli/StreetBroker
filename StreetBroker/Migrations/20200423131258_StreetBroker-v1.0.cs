using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StreetBroker.Migrations
{
    public partial class StreetBrokerv10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cor");

            migrationBuilder.EnsureSchema(
                name: "repo");

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "cor",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    record_status = table.Column<byte>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false),
                    first_name = table.Column<string>(maxLength: 500, nullable: false),
                    last_name = table.Column<string>(maxLength: 250, nullable: false),
                    email = table.Column<string>(maxLength: 500, nullable: false),
                    address = table.Column<string>(maxLength: 700, nullable: true),
                    city = table.Column<string>(maxLength: 250, nullable: true),
                    country = table.Column<string>(maxLength: 250, nullable: true),
                    zip = table.Column<int>(nullable: false),
                    gender = table.Column<string>(maxLength: 10, nullable: true),
                    phone_number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dealer",
                schema: "cor",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    record_status = table.Column<byte>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false),
                    first_name = table.Column<string>(maxLength: 500, nullable: false),
                    last_name = table.Column<string>(maxLength: 250, nullable: true),
                    email = table.Column<string>(maxLength: 500, nullable: false),
                    phone_number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "repo_order",
                schema: "repo",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    record_status = table.Column<byte>(nullable: false),
                    created_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: false),
                    dealer_id = table.Column<long>(nullable: false),
                    customer_id = table.Column<long>(nullable: false),
                    net_interest_rate = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    gross_interest_rate = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    net_interest_amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    gross_interest_amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    return_net_interest_amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    return_gross_interest_amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    tax_amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    maturity = table.Column<DateTime>(type: "Date", nullable: false),
                    start_date = table.Column<DateTime>(type: "Date", nullable: false),
                    order_status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repo_order", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer",
                schema: "cor");

            migrationBuilder.DropTable(
                name: "dealer",
                schema: "cor");

            migrationBuilder.DropTable(
                name: "repo_order",
                schema: "repo");
        }
    }
}
