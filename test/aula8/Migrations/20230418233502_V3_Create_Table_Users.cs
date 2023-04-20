using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aula8.Migrations
{
    /// <inheritdoc />
    public partial class V3_Create_Table_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("" +
                "Create Table users( " +
                "id bigint  NOT NULL  IDENTITY(0, 1) PRIMARY KEY," +
                "user_name varchar(50) not null Default '0', " +
                "password varchar(130) not null Default '0', " +
                "full_name varchar(120) not null ," +
                "refresh_token varchar(500) null Default '0', " +
                "refresh_token_expiry_time  datetime null Default null, " +
                "unique(user_name))" +
                "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
