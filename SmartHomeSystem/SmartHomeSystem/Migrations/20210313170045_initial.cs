using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace SmartHomeSystem.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableVals",
                columns: table => new
                {
                    AvailableValuesId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableVals", x => x.AvailableValuesId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceParameterCurrentValues",
                columns: table => new
                {
                    DeviceParamCurrentValId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceParameterCurrentValues", x => x.DeviceParamCurrentValId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    DeviceTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.DeviceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTypeAvailableValues",
                columns: table => new
                {
                    DeviceTypeAvailableValuesId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DeviceTypeId = table.Column<int>(nullable: false),
                    AvailableValsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypeAvailableValues", x => x.DeviceTypeAvailableValuesId);
                    table.ForeignKey(
                        name: "FK_DeviceTypeAvailableValues_AvailableVals_AvailableValsId",
                        column: x => x.AvailableValsId,
                        principalTable: "AvailableVals",
                        principalColumn: "AvailableValuesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceTypeAvailableValues_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypes",
                        principalColumn: "DeviceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumberParameters",
                columns: table => new
                {
                    NumberParameterId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MinValue = table.Column<int>(nullable: false),
                    MaxValue = table.Column<int>(nullable: false),
                    DefaultValue = table.Column<int>(nullable: false),
                    DeviceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberParameters", x => x.NumberParameterId);
                    table.ForeignKey(
                        name: "FK_NumberParameters_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypes",
                        principalColumn: "DeviceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StringParameters",
                columns: table => new
                {
                    StringParameterId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsLimitedToAvailableValue = table.Column<bool>(nullable: false),
                    DefaultValue = table.Column<string>(nullable: true),
                    DeviceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringParameters", x => x.StringParameterId);
                    table.ForeignKey(
                        name: "FK_StringParameters_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypes",
                        principalColumn: "DeviceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    HomeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.HomeId);
                    table.ForeignKey(
                        name: "FK_Homes_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DeviceHomeHomeId = table.Column<int>(nullable: true),
                    DeviceTypeId = table.Column<int>(nullable: true),
                    DPCurrentValue = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceParameterCurrentValues_DPCurrentValue",
                        column: x => x.DPCurrentValue,
                        principalTable: "DeviceParameterCurrentValues",
                        principalColumn: "DeviceParamCurrentValId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Homes_DeviceHomeHomeId",
                        column: x => x.DeviceHomeHomeId,
                        principalTable: "Homes",
                        principalColumn: "HomeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypes",
                        principalColumn: "DeviceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserHomes",
                columns: table => new
                {
                    UserHomeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HomeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHomes", x => x.UserHomeId);
                    table.ForeignKey(
                        name: "FK_UserHomes_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "HomeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHomes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archives",
                columns: table => new
                {
                    ArchiveId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDeviceId = table.Column<int>(nullable: true),
                    UpdatedValueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archives", x => x.ArchiveId);
                    table.ForeignKey(
                        name: "FK_Archives_Devices_UpdatedDeviceId",
                        column: x => x.UpdatedDeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Archives_DeviceParameterCurrentValues_UpdatedValueId",
                        column: x => x.UpdatedValueId,
                        principalTable: "DeviceParameterCurrentValues",
                        principalColumn: "DeviceParamCurrentValId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DevicesCurrentValues",
                columns: table => new
                {
                    DevicesCurrentValuesId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<int>(nullable: false),
                    DeviceParameterCurrentValueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicesCurrentValues", x => x.DevicesCurrentValuesId);
                    table.ForeignKey(
                        name: "FK_DevicesCurrentValues_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevicesCurrentValues_DeviceParameterCurrentValues_DevicePara~",
                        column: x => x.DeviceParameterCurrentValueId,
                        principalTable: "DeviceParameterCurrentValues",
                        principalColumn: "DeviceParamCurrentValId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archives_UpdatedDeviceId",
                table: "Archives",
                column: "UpdatedDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Archives_UpdatedValueId",
                table: "Archives",
                column: "UpdatedValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DPCurrentValue",
                table: "Devices",
                column: "DPCurrentValue");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceHomeHomeId",
                table: "Devices",
                column: "DeviceHomeHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicesCurrentValues_DeviceId",
                table: "DevicesCurrentValues",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicesCurrentValues_DeviceParameterCurrentValueId",
                table: "DevicesCurrentValues",
                column: "DeviceParameterCurrentValueId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypeAvailableValues_AvailableValsId",
                table: "DeviceTypeAvailableValues",
                column: "AvailableValsId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypeAvailableValues_DeviceTypeId",
                table: "DeviceTypeAvailableValues",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_OwnerUserId",
                table: "Homes",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberParameters_DeviceTypeId",
                table: "NumberParameters",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StringParameters_DeviceTypeId",
                table: "StringParameters",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHomes_HomeId",
                table: "UserHomes",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHomes_UserId",
                table: "UserHomes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archives");

            migrationBuilder.DropTable(
                name: "DevicesCurrentValues");

            migrationBuilder.DropTable(
                name: "DeviceTypeAvailableValues");

            migrationBuilder.DropTable(
                name: "NumberParameters");

            migrationBuilder.DropTable(
                name: "StringParameters");

            migrationBuilder.DropTable(
                name: "UserHomes");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "AvailableVals");

            migrationBuilder.DropTable(
                name: "DeviceParameterCurrentValues");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
