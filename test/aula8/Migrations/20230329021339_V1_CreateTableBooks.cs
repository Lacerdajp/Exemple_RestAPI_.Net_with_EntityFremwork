using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aula8.Migrations
{
    /// <inheritdoc />
    public partial class V1_CreateTableBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("" +
                "create TABLE books(" +
                "id bigint  NOT NULL  IDENTITY(0, 1) PRIMARY KEY," +
                "autor varchar(100) NOT NULL," +
                "titulo varchar(80) NOT NULL," +
                "valor decimal(38,2) NOT NULL," +
                   "data datetime NOT NULL," +
                   ")");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
