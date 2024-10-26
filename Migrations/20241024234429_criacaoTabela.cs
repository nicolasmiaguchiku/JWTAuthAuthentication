using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTAuthAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class criacaoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Role" },
                values: new object[] { "$2a$11$OLNgAqLGAqKN5qHKQ.xw9Ox2FNEhtp/7j9oJRX07UxIIl.7xmrli.", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Role" },
                values: new object[] { "$2a$11$n9B4/W8NZ8lkn9ymlLDUae6O3q4LeQyG2yWwb7uatkhUhY0trMiBS", "Admin" });
        }
    }
}
