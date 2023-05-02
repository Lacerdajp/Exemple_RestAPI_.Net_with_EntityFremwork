using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aula8.Migrations
{
    /// <inheritdoc />
    public partial class V5_Create_Column_Enabled_Person : Migration
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
