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
                name: "repo");

            migrationBuilder.CreateTable(
                name: "repo_order",
                schema: "repo",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dealer_id = table.Column<long>(nullable: false),
                    customer_id = table.Column<long>(nullable: false),
                    record_status = table.Column<byte>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
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
                name: "repo_order",
                schema: "repo");
        }
    }
}
