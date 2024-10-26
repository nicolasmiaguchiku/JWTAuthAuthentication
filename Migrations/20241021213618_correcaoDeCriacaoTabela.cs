using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTAuthAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class correcaoDeCriacaoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "Role" },
                values: new object[] { 1, "nicolaseeisuke@gmail.com", "Nicolas", "$2a$11$n9B4/W8NZ8lkn9ymlLDUae6O3q4LeQyG2yWwb7uatkhUhY0trMiBS", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
