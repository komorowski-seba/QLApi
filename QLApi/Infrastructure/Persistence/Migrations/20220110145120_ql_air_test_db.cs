using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class ql_air_test_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirTestHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StationId = table.Column<long>(type: "bigint", nullable: false),
                    LastTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirTestHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationId = table.Column<long>(type: "bigint", nullable: false),
                    CalcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DownloadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    So2IndexLevel = table.Column<int>(type: "int", nullable: false),
                    So2IndexName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No2IndexLevel = table.Column<int>(type: "int", nullable: false),
                    No2IndexName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pm10IndexLevel = table.Column<int>(type: "int", nullable: false),
                    Pm10IndexName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pm25IndexLevel = table.Column<int>(type: "int", nullable: false),
                    Pm25IndexName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    O3IndexLevel = table.Column<int>(type: "int", nullable: false),
                    O3IndexName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirTests_AirTestHistories_AirHistoryId",
                        column: x => x.AirHistoryId,
                        principalTable: "AirTestHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Communes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommuneName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communes_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommuneId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Communes_CommuneId",
                        column: x => x.CommuneId,
                        principalTable: "Communes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GegrLat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GegrLon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirTests_AirHistoryId",
                table: "AirTests",
                column: "AirHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CommuneId",
                table: "Cities",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_ProvinceId",
                table: "Communes",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_CityId",
                table: "Stations",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirTests");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "AirTestHistories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Communes");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
