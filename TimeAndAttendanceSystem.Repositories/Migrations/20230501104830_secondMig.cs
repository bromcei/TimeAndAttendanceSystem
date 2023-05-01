using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeAndAttendanceSystem.Repositories.Migrations
{
    public partial class secondMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserDetails",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserDetails",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);
        }
    }
}
