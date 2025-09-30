using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class emptyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var adminRoleId = 1;
            var userRoleId = 2;

            var users = new (Guid Id, string Name, string Email, string Password, int RoleId, string Address)[]
            {
                (Guid.NewGuid(), "Admin One", "admin1@survey.com", "Admin@123", adminRoleId, "Admin Street 1"),
                (Guid.NewGuid(), "Admin Two", "admin2@survey.com", "Admin@123", adminRoleId, "Admin Street 2"),
                (Guid.NewGuid(), "Admin Three", "admin3@survey.com", "Admin@123", adminRoleId, "Admin Street 3"),

                (Guid.NewGuid(), "User One", "user1@survey.com", "User@123", userRoleId, "User Colony 1"),
                (Guid.NewGuid(), "User Two", "user2@survey.com", "User@123", userRoleId, "User Colony 2"),
                (Guid.NewGuid(), "User Three", "user3@survey.com", "User@123", userRoleId, "User Colony 3"),
            };

            foreach (var user in users)
            {
                var hash = BCrypt.Net.BCrypt.HashPassword(user.Password);

                migrationBuilder.InsertData(
                    table: "Users",
                    columns: new[] { "Id", "Name", "Email", "Password", "RoleId", "Address" },
                    values: new object[]
                    {
                        user.Id,
                        user.Name,
                        user.Email,
                        hash,
                        user.RoleId,
                        user.Address
                    }
                );
            }

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Users] WHERE Email LIKE '%@survey.com'");
        }
    }
}
