using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourOSBB.Web.Migrations
{
    /// <inheritdoc />
    public partial class MigrationChangeCompletedPollTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedPoll_PollCandidate_WinnerPollCandidateId",
                table: "CompletedPoll");

            migrationBuilder.DropIndex(
                name: "IX_CompletedPoll_WinnerPollCandidateId",
                table: "CompletedPoll");

            migrationBuilder.DropColumn(
                name: "WinnerPollCandidateId",
                table: "CompletedPoll");

            migrationBuilder.AddColumn<string>(
                name: "WinnerPollCandidateName",
                table: "CompletedPoll",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerPollCandidateName",
                table: "CompletedPoll");

            migrationBuilder.AddColumn<int>(
                name: "WinnerPollCandidateId",
                table: "CompletedPoll",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedPoll_WinnerPollCandidateId",
                table: "CompletedPoll",
                column: "WinnerPollCandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedPoll_PollCandidate_WinnerPollCandidateId",
                table: "CompletedPoll",
                column: "WinnerPollCandidateId",
                principalTable: "PollCandidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
