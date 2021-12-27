using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tweeter.Data.Migrations
{
    public partial class LikesAndFollowsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Likes_TweetId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FolloweeId",
                table: "Follows");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "TEXT",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Users",
                type: "TEXT",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Tweets",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_TweetId_UserId",
                table: "Likes",
                columns: new[] { "TweetId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FolloweeId_FollowerId",
                table: "Follows",
                columns: new[] { "FolloweeId", "FollowerId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Likes_TweetId_UserId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FolloweeId_FollowerId",
                table: "Follows");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "TEXT",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Users",
                type: "TEXT",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Tweets",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_TweetId",
                table: "Likes",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FolloweeId",
                table: "Follows",
                column: "FolloweeId");
        }
    }
}
