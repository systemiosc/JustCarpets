using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JustCarpets.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    AgreedDataProtection = table.Column<DateTime>(nullable: false),
                    AgreedTerms = table.Column<DateTime>(nullable: false),
                    AgreedMarketing = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carpet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Style = table.Column<int>(nullable: false),
                    DurabilityFactor = table.Column<int>(nullable: false),
                    PetFriendly = table.Column<bool>(nullable: false),
                    PriceM2 = table.Column<decimal>(nullable: false),
                    CompanyEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carpet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carpet_Company_CompanyEntityId",
                        column: x => x.CompanyEntityId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyLocations_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    InstallerReviewId = table.Column<int>(nullable: false),
                    InstallerDate = table.Column<int>(nullable: false),
                    ReviewDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarpetColourPallet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(nullable: true),
                    Hex = table.Column<string>(nullable: true),
                    RGB = table.Column<string>(nullable: true),
                    CarpetId = table.Column<int>(nullable: false),
                    CarpetEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpetColourPallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarpetColourPallet_Carpet_CarpetEntityId",
                        column: x => x.CarpetEntityId,
                        principalTable: "Carpet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarpetColourPallet_Carpet_CarpetId",
                        column: x => x.CarpetId,
                        principalTable: "Carpet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarpetImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(nullable: true),
                    AlternateText = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    ImageType = table.Column<int>(nullable: false),
                    CarpetId = table.Column<int>(nullable: false),
                    CarpetEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpetImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarpetImage_Carpet_CarpetEntityId",
                        column: x => x.CarpetEntityId,
                        principalTable: "Carpet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarpetImage_Carpet_CarpetId",
                        column: x => x.CarpetId,
                        principalTable: "Carpet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarpetPropertys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BulletPoint = table.Column<string>(nullable: true),
                    CarpetId = table.Column<int>(nullable: false),
                    CarpetEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpetPropertys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarpetPropertys_Carpet_CarpetEntityId",
                        column: x => x.CarpetEntityId,
                        principalTable: "Carpet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarpetPropertys_Carpet_CarpetId",
                        column: x => x.CarpetId,
                        principalTable: "Carpet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarpetSizeOptionEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Width = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    M2 = table.Column<int>(nullable: false),
                    CarpetId = table.Column<int>(nullable: false),
                    CarpetEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpetSizeOptionEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarpetSizeOptionEntity_Carpet_CarpetEntityId",
                        column: x => x.CarpetEntityId,
                        principalTable: "Carpet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarpetSizeOptionEntity_Carpet_CarpetId",
                        column: x => x.CarpetId,
                        principalTable: "Carpet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstallerRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyLocationId = table.Column<int>(nullable: false),
                    HalfDayRate = table.Column<decimal>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallerRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallerRates_CompanyLocations_CompanyLocationId",
                        column: x => x.CompanyLocationId,
                        principalTable: "CompanyLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstallerAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    AM = table.Column<bool>(nullable: false),
                    InstallerId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallerAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallerAppointment_CompanyLocations_InstallerId",
                        column: x => x.InstallerId,
                        principalTable: "CompanyLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstallerAppointment_CustomerOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "CustomerOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstallerReview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PunctualityFactor = table.Column<int>(nullable: false),
                    TimeKeepingFactor = table.Column<int>(nullable: false),
                    CleanupFactor = table.Column<int>(nullable: false),
                    QualityFactor = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CustomerOrderId = table.Column<int>(nullable: false),
                    InstallerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallerReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallerReview_CustomerOrder_CustomerOrderId",
                        column: x => x.CustomerOrderId,
                        principalTable: "CustomerOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstallerReview_CompanyLocations_InstallerId",
                        column: x => x.InstallerId,
                        principalTable: "CompanyLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarpetId = table.Column<int>(nullable: false),
                    CarpetSizeOptionId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    CustomerOrderId = table.Column<int>(nullable: false),
                    SizeOptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLine_Carpet_CarpetId",
                        column: x => x.CarpetId,
                        principalTable: "Carpet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLine_CustomerOrder_CustomerOrderId",
                        column: x => x.CustomerOrderId,
                        principalTable: "CustomerOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLine_CarpetSizeOptionEntity_SizeOptionId",
                        column: x => x.SizeOptionId,
                        principalTable: "CarpetSizeOptionEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carpet_CompanyEntityId",
                table: "Carpet",
                column: "CompanyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetColourPallet_CarpetEntityId",
                table: "CarpetColourPallet",
                column: "CarpetEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetColourPallet_CarpetId",
                table: "CarpetColourPallet",
                column: "CarpetId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetImage_CarpetEntityId",
                table: "CarpetImage",
                column: "CarpetEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetImage_CarpetId",
                table: "CarpetImage",
                column: "CarpetId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetPropertys_CarpetEntityId",
                table: "CarpetPropertys",
                column: "CarpetEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetPropertys_CarpetId",
                table: "CarpetPropertys",
                column: "CarpetId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetSizeOptionEntity_CarpetEntityId",
                table: "CarpetSizeOptionEntity",
                column: "CarpetEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetSizeOptionEntity_CarpetId",
                table: "CarpetSizeOptionEntity",
                column: "CarpetId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLocations_CompanyId",
                table: "CompanyLocations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_CustomerId",
                table: "CustomerOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallerAppointment_InstallerId",
                table: "InstallerAppointment",
                column: "InstallerId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallerAppointment_OrderId",
                table: "InstallerAppointment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallerRates_CompanyLocationId",
                table: "InstallerRates",
                column: "CompanyLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallerReview_CustomerOrderId",
                table: "InstallerReview",
                column: "CustomerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallerReview_InstallerId",
                table: "InstallerReview",
                column: "InstallerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_CarpetId",
                table: "OrderLine",
                column: "CarpetId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_CustomerOrderId",
                table: "OrderLine",
                column: "CustomerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_SizeOptionId",
                table: "OrderLine",
                column: "SizeOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarpetColourPallet");

            migrationBuilder.DropTable(
                name: "CarpetImage");

            migrationBuilder.DropTable(
                name: "CarpetPropertys");

            migrationBuilder.DropTable(
                name: "InstallerAppointment");

            migrationBuilder.DropTable(
                name: "InstallerRates");

            migrationBuilder.DropTable(
                name: "InstallerReview");

            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "CompanyLocations");

            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropTable(
                name: "CarpetSizeOptionEntity");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Carpet");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
