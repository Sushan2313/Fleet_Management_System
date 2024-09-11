using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fleetmanagementnew.Migrations
{
    /// <inheritdoc />
    public partial class Fleetmanagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Customers ON");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
