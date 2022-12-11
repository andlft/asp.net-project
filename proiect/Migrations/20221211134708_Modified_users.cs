using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect.Migrations
{
    /// <inheritdoc />
    public partial class Modifiedusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_Customer_CustomerId",
                table: "Adress");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Adress",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Adress_CustomerId",
                table: "Adress",
                newName: "IX_Adress_UserId");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleName",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_Customer_UserId",
                table: "Adress",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_Customer_UserId",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Adress",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Adress_UserId",
                table: "Adress",
                newName: "IX_Adress_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_Customer_CustomerId",
                table: "Adress",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
