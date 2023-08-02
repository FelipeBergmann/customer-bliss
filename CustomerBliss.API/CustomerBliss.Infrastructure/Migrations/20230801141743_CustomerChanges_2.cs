using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerBliss.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomerChanges_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastReviewDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastReviewDate",
                table: "Customers");
        }
    }
}
