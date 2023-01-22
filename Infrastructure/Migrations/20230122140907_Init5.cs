using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobGrades",
                table: "JobGrades");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JobGrades",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobGrades",
                table: "JobGrades",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobGrades",
                table: "JobGrades");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobGrades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobGrades",
                table: "JobGrades",
                column: "Gradelevel");
        }
    }
}
