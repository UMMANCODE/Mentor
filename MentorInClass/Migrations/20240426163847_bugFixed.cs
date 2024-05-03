using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorInClass.Migrations
{
    /// <inheritdoc />
    public partial class bugFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturePricing_Pricing_PricingsId",
                table: "FeaturePricing");

            migrationBuilder.DropForeignKey(
                name: "FK_PricingFeatures_Pricing_PricingId",
                table: "PricingFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pricing",
                table: "Pricing");

            migrationBuilder.RenameTable(
                name: "Pricing",
                newName: "Pricings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pricings",
                table: "Pricings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturePricing_Pricings_PricingsId",
                table: "FeaturePricing",
                column: "PricingsId",
                principalTable: "Pricings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PricingFeatures_Pricings_PricingId",
                table: "PricingFeatures",
                column: "PricingId",
                principalTable: "Pricings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturePricing_Pricings_PricingsId",
                table: "FeaturePricing");

            migrationBuilder.DropForeignKey(
                name: "FK_PricingFeatures_Pricings_PricingId",
                table: "PricingFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pricings",
                table: "Pricings");

            migrationBuilder.RenameTable(
                name: "Pricings",
                newName: "Pricing");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pricing",
                table: "Pricing",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturePricing_Pricing_PricingsId",
                table: "FeaturePricing",
                column: "PricingsId",
                principalTable: "Pricing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PricingFeatures_Pricing_PricingId",
                table: "PricingFeatures",
                column: "PricingId",
                principalTable: "Pricing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
