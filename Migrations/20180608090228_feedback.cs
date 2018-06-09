using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataSystem.Migrations
{
    public partial class feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Initiator = table.Column<string>(maxLength: 255, nullable: true),
                    NMRID = table.Column<string>(maxLength: 100, nullable: true),
                    Problem = table.Column<string>(maxLength: 255, nullable: true),
                    Respondent = table.Column<string>(maxLength: 255, nullable: true),
                    Respose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_NMR",
                        column: x => x.NMRID,
                        principalTable: "NMR",
                        principalColumn: "NMRID",
                        onDelete: ReferentialAction.Restrict);
                });




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "vImplementer");

            migrationBuilder.DropTable(
                name: "vProvince");

            migrationBuilder.DropTable(
                name: "yFilter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TempFacility",
                table: "TempFacility");

            migrationBuilder.DropIndex(
                name: "IX_TempFacility_FacilityID",
                table: "TempFacility");

            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "monthlysubmission");

            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "checkcompleteness");

            migrationBuilder.AddColumn<int>(
                name: "IYCF_submission",
                table: "nmrsubmission",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "LON",
                table: "TempFacility",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationPashto",
                table: "TempFacility",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationDari",
                table: "TempFacility",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "TempFacility",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "LAT",
                table: "TempFacility",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Implementer",
                table: "TempFacility",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SFP_AWG",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SFP_ALS",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OAWG_Marasmus",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OAWG_Kwashiorkor",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OALS_Marasmus",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OALS_Kwashiorkor",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IAWG_Marasmus",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IAWG_Kwashiorkor",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IALS_Marasmus",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IALS_Kwashiorkor",
                table: "NMR",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
