using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aula8.Migrations
{
    /// <inheritdoc />
    public partial class V4_Enabled_PersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("" +
                   "alter table  person " +
                   "add column enabled  boolean not null default true  " +
                   "");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
