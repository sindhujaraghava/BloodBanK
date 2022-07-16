using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBanK.Migrations
{
    public partial class BloodBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hospitals",
                columns: table => new
                {
                    HospitalName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospitals", x => x.HospitalName);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "slots",
                columns: table => new
                {
                    SlotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlotTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HospitalName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slots", x => x.SlotId);
                    table.ForeignKey(
                        name: "FK_slots_hospitals_HospitalName",
                        column: x => x.HospitalName,
                        principalTable: "hospitals",
                        principalColumn: "HospitalName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reqs",
                columns: table => new
                {
                    ReqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SlotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reqs", x => x.ReqId);
                    table.ForeignKey(
                        name: "FK_reqs_slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "slots",
                        principalColumn: "SlotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reqs_users_UserName",
                        column: x => x.UserName,
                        principalTable: "users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reqs_SlotId",
                table: "reqs",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_reqs_UserName",
                table: "reqs",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_slots_HospitalName",
                table: "slots",
                column: "HospitalName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reqs");

            migrationBuilder.DropTable(
                name: "slots");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "hospitals");
        }
    }
}
