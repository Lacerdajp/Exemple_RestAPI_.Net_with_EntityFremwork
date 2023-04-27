using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aula8.Migrations
{
    /// <inheritdoc />
    public partial class InserindoDadosDeUmUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO users " +
                "(user_name, password, full_name, refresh_token, refresh_token_expiry_time) " +
                "VALUES('JPLS', '46-07-0D-4B-F9-34-FB-0D-4B-06-D9-E2-C4-6E-34-69-44-E3-22-44-49-00-A4-35-D7-D9-A9-5E-6D-74-35-F5'," +
                " 'João Pedro Lacerda de Souza', " +
                "'h9lzVOoLlBoTbcQrh/e16/aIj+4p6C67lLdDbBRMsjE=', " +
                "'2023-04-24 00:00:00' )" +
                "" +
                "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
        }
    }
}
