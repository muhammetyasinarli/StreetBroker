using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StreetBroker.Migrations
{
    public partial class StreetBrokerv11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cor");

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "cor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    record_status = table.Column<byte>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
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
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    record_status = table.Column<byte>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_date = table.Column<DateTime>(nullable: false),
                    first_name = table.Column<string>(maxLength: 500, nullable: false),
                    last_name = table.Column<string>(maxLength: 250, nullable: true),
                    email = table.Column<string>(maxLength: 500, nullable: false),
                    phone_number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealer", x => x.id);
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
        }
    }
}
