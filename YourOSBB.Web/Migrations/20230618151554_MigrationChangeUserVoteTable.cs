using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourOSBB.Web.Migrations
{
    /// <inheritdoc />
    public partial class MigrationChangeUserVoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PollId",
                table: "UserVote",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PollId",
                table: "UserVote");
        }
    }
}
