using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureHardwareLogisticsAPI.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDecommissioned",
                table: "HardwareAssets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDecommissioned",
                table: "AuditLogs",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDecommissioned",
                table: "HardwareAssets");

            migrationBuilder.DropColumn(
                name: "IsDecommissioned",
                table: "AuditLogs");
        }
    }
}
