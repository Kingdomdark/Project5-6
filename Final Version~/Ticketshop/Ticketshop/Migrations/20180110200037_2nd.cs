using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketshop.Migrations
{
    public partial class _2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Wishlists_WishlistCustomerEmail",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_WishlistCustomerEmail",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "WishlistCustomerEmail",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Wishlists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Wishlists");

            migrationBuilder.AddColumn<string>(
                name: "WishlistCustomerEmail",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_WishlistCustomerEmail",
                table: "Events",
                column: "WishlistCustomerEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Wishlists_WishlistCustomerEmail",
                table: "Events",
                column: "WishlistCustomerEmail",
                principalTable: "Wishlists",
                principalColumn: "CustomerEmail",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
