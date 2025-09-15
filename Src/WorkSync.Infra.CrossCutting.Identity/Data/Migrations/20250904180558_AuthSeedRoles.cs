using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSync.Infra.CrossCutting.Identity.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuthSeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                 "AspNetRoles",
                 ["Id", "Name", "NormalizedName", "ConcurrencyStamp"],
                 new object[,]
                 {
                     { "1", "Admin", "ADMIN", Guid.NewGuid().ToString() },
                     { "2", "Recruiter", "RECRUITER", Guid.NewGuid().ToString() },
                 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "AspNetRoles",
                "Id",
                "1");
            migrationBuilder.DeleteData(
                "AspNetRoles",
                "Id",
                "2");
        }
    }
}
