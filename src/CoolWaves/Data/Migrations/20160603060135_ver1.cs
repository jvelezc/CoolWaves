using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoolWaves.Data.Migrations
{
    public partial class ver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "AspNetUser",
                schema: "Security",
                columns: table => new
                {
                    AspNetUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Test = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUser", x => x.AspNetUserId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRole",
                schema: "Security",
                columns: table => new
                {
                    AspNetRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRole", x => x.AspNetRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserToken",
                schema: "Security",
                columns: table => new
                {
                    AspNetUserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserToken", x => new { x.AspNetUserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaim",
                schema: "Security",
                columns: table => new
                {
                    AspNetUserClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaim", x => x.AspNetUserClaimId);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaim_AspNetUser_UserId",
                        column: x => x.AspNetUserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUser",
                        principalColumn: "AspNetUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogin",
                schema: "Security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogin_AspNetUser_UserId",
                        column: x => x.AspNetUserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUser",
                        principalColumn: "AspNetUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaim",
                schema: "Security",
                columns: table => new
                {
                    AspNetRoleClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    AspNetRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaim", x => x.AspNetRoleClaimId);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaim_AspNetRole_RoleId",
                        column: x => x.AspNetRoleId,
                        principalSchema: "Security",
                        principalTable: "AspNetRole",
                        principalColumn: "AspNetRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRole",
                schema: "Security",
                columns: table => new
                {
                    AspNetUserId = table.Column<int>(nullable: false),
                    AspNetRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRole", x => new { x.AspNetUserId, x.AspNetRoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRole_AspNetRole_RoleId",
                        column: x => x.AspNetRoleId,
                        principalSchema: "Security",
                        principalTable: "AspNetRole",
                        principalColumn: "AspNetRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRole_AspNetUser_UserId",
                        column: x => x.AspNetUserId,
                        principalSchema: "Security",
                        principalTable: "AspNetUser",
                        principalColumn: "AspNetUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "AspNetUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "AspNetUser",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "AspNetRole",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaim_RoleId",
                schema: "Security",
                table: "AspNetRoleClaim",
                column: "AspNetRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaim_UserId",
                schema: "Security",
                table: "AspNetUserClaim",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogin_UserId",
                schema: "Security",
                table: "AspNetUserLogin",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRole_RoleId",
                schema: "Security",
                table: "AspNetUserRole",
                column: "AspNetRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRole_UserId",
                schema: "Security",
                table: "AspNetUserRole",
                column: "AspNetUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaim",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserClaim",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserLogin",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUserToken",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "AspNetUser",
                schema: "Security");
        }
    }
}
