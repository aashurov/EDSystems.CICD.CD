using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EDSystems.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class myMigration01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "varchar", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Code = table.Column<string>(type: "varchar", maxLength: 4, nullable: true),
                    Number = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "varchar", maxLength: 250, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<int>(type: "integer", maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    Cost = table.Column<decimal>(type: "numeric(18,3)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 500, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    JwtId = table.Column<string>(type: "text", nullable: true),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpiryDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TokenId = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Balance = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToBranchId = table.Column<int>(type: "integer", nullable: false),
                    FromBranchId = table.Column<int>(type: "integer", nullable: false),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelBranch_Branch_FromBranchId",
                        column: x => x.FromBranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParcelBranch_Branch_ToBranchId",
                        column: x => x.ToBranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ParcelBranch_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StateDeliveryToBranch = table.Column<bool>(type: "boolean", nullable: false),
                    StatePickingUp = table.Column<bool>(type: "boolean", nullable: false),
                    StateDeliveryToPoint = table.Column<bool>(type: "boolean", nullable: false),
                    StateBuyout = table.Column<bool>(type: "boolean", nullable: false),
                    CostPickingUp = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    CostDeliveryToPoint = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    CostDeliveryToBranch = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    CostBuyout = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelCost_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelCost_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "varchar", maxLength: 500, nullable: true),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelDescription_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageName = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    ImageBytes = table.Column<string>(type: "varchar", nullable: true),
                    ParcelId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelImage_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<string>(type: "varchar(200)", nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    ParcelId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelItem_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelItem_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelJob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cost = table.Column<decimal>(type: "numeric(18,3)", maxLength: 20, nullable: false),
                    CourierId = table.Column<string>(type: "text", nullable: true),
                    JobType = table.Column<string>(type: "varchar", maxLength: 15, nullable: true),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    PaymentState = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelJob_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<decimal>(type: "numeric(18,3)", maxLength: 20, nullable: false),
                    NumberOfPoint = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelSize_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelSound",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SoundName = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    SoundBytes = table.Column<string>(type: "varchar", nullable: true),
                    ParcelId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelSound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelSound_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanId = table.Column<int>(type: "integer", nullable: false),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelPlan_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelPlan_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ParcelStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    ParcelId = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelStatus_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    UserNameT = table.Column<string>(type: "text", nullable: true),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ParcelJobId = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ParcelJob_ParcelJobId",
                        column: x => x.ParcelJobId,
                        principalTable: "ParcelJob",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    JobType = table.Column<bool>(type: "bool", nullable: false),
                    BranchAccountId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    PayerId = table.Column<string>(type: "text", nullable: true),
                    PayerId1 = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountHistory_Account_BranchAccountId",
                        column: x => x.BranchAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountHistory_AspNetUsers_PayerId1",
                        column: x => x.PayerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountHistory_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountHistory_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<string>(type: "text", nullable: true),
                    SenderId1 = table.Column<int>(type: "integer", nullable: true),
                    RecepientId = table.Column<string>(type: "text", nullable: true),
                    RecepientId1 = table.Column<int>(type: "integer", nullable: true),
                    RecepientStaffId = table.Column<string>(type: "text", nullable: true),
                    RecepientStaffId1 = table.Column<int>(type: "integer", nullable: true),
                    SenderStaffId = table.Column<string>(type: "text", nullable: true),
                    SenderStaffId1 = table.Column<int>(type: "integer", nullable: true),
                    RecepientCourierId = table.Column<string>(type: "text", nullable: true),
                    RecepientCourierId1 = table.Column<int>(type: "integer", nullable: true),
                    SenderCourierId = table.Column<string>(type: "text", nullable: true),
                    SenderCourierId1 = table.Column<int>(type: "integer", nullable: true),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_RecepientCourierId1",
                        column: x => x.RecepientCourierId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_RecepientId1",
                        column: x => x.RecepientId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_RecepientStaffId1",
                        column: x => x.RecepientStaffId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_SenderCourierId1",
                        column: x => x.SenderCourierId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_SenderId1",
                        column: x => x.SenderId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_SenderStaffId1",
                        column: x => x.SenderStaffId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Balance = table.Column<decimal>(type: "numeric", maxLength: 20, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<int>(type: "integer", nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccount_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccount_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    JobType = table.Column<bool>(type: "bool", nullable: false),
                    UserAccountId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<int>(type: "integer", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccountHistory_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccountHistory_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccountHistory_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccountHistory_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "62d65bae-26fe-4478-8c5a-028912ed52f8", "Administrator", "ADMINISTRATOR" },
                    { 2, "745a2a87-3eec-4831-9648-ff3e0ca27f5f", "Manager", "MANAGER" },
                    { 3, "ca38d0cc-67c2-4fcb-83fa-9ecdd0ee6130", "Staff", "STAFF" },
                    { 4, "18be39b6-69fa-4303-acb2-13c9ad627d6e", "Courier", "COURIER" },
                    { 5, "3072d295-e268-445f-9aae-2c5c58501d87", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ChatId", "ConcurrencyStamp", "DateCreated", "DateUpdated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParcelJobId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserNameT" },
                values: new object[,]
                {
                    { 1, 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "537ead06-91c5-4e77-9d74-8a4c24c98c0c", new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1260), null, "administrator@gmail.com", false, "EDSystem", "Administrator", false, null, "ADMINISTRATOR@GMAIL.COM", "ADMINISTRATOR", null, "AQAAAAIAAYagAAAAEG96UZInZlqlB7GEfsljsHadi+M+gyuEt9ueoxFf/3f3wCIWCDN9c+bQaOWsM8M05A==", "998970000675", false, null, false, "administrator", "UserName" },
                    { 2, 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "4d518d26-2c13-460b-b918-30d018a73dce", new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1270), null, "hayrulloh@gmail.com", false, "EDTashkent", "Hayrulloh", false, null, "HAYRULLOH@GMAIL.COM", "HAYRULLOH", null, "AQAAAAIAAYagAAAAEG96UZInZlqlB7GEfsljsHadi+M+gyuEt9ueoxFf/3f3wCIWCDN9c+bQaOWsM8M05A==", "998935788886", false, null, false, "hayrulloh", "UserName" },
                    { 3, 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "99484c3d-c5a9-40b4-996f-43b88d4fd06e", new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1280), null, "Nodir@gmail.com", false, "EDTashkent", "Nodir", false, null, "NODIR@GMAIL.COM", "NODIR", null, "AQAAAAIAAYagAAAAEG96UZInZlqlB7GEfsljsHadi+M+gyuEt9ueoxFf/3f3wCIWCDN9c+bQaOWsM8M05A==", "998909046605", false, null, false, "nodir", "UserName" },
                    { 4, 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "7dfa1f3d-3dfb-4990-b102-f2254a385477", new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1310), null, "Javohir@gmail.com", false, "EDTashkent", "Javohir", false, null, "JAVOHIR@GMAIL.COM", "JAVOHIR", null, "AQAAAAIAAYagAAAAEG96UZInZlqlB7GEfsljsHadi+M+gyuEt9ueoxFf/3f3wCIWCDN9c+bQaOWsM8M05A==", "998931710966", false, null, false, "javohir", "UserName" },
                    { 5, 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "97a5ddd0-0a30-4208-af4d-79f82fe2dbcd", new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1320), null, "Ismoil@gmail.com", false, "EDTashkent", "Ismoil", false, null, "ISMOIL@GMAIL.COM", "ISMOIL", null, "AQAAAAIAAYagAAAAEG96UZInZlqlB7GEfsljsHadi+M+gyuEt9ueoxFf/3f3wCIWCDN9c+bQaOWsM8M05A==", "998977093262", false, null, false, "ismoil", "UserName" }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Address", "City", "Code", "Country", "CreatedBy", "DateCreated", "DateUpdated", "Email", "ModifiedBy", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", "Москва", "643", "Россия", null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(150), null, "info@ethnologistics.asia", null, "Москва", "+765165498496" },
                    { 2, "Республика Узбекистан, г. Ташкент, Юнусабадский район, улица Кашгар 11,", "Ташкент", "860", "Узбекистан", null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(150), null, "info@ethnologistics.asia", null, "Ташкент", "+998984651" },
                    { 3, "Киргизия, Бишкек, Жибек-Жолу д 443/1", "Бишкек", "417", "Киргистан", null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(150), null, "info@ethnologistics.asia", null, "Бишкек", "+765165498496" },
                    { 4, "Душанбе 122", "Душанбе", "762", "Таджикистан", null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(160), null, "info@ethnologistics.asia", null, "Душанбе", "+665165498496" },
                    { 5, "Алматы 123", "Алматы", "398", "Казахстан", null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(160), null, "info@ethnologistics.asia", null, "Алматы", "+665165498496" },
                    { 6, "Хайдарпашша", "Стамбул", "792", "Турция", null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(160), null, "info@ethnologistics.asia", null, "Стамбул", "+665165498496" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code", "Country", "CreatedBy", "DateCreated", "DateUpdated", "ModifiedBy", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "USD", "Соединенные Штаты Америки", null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1420), null, null, "Доллар", 840 },
                    { 2, "UZS", "Республика Узбекистан", null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1420), null, null, "Сум", 860 },
                    { 3, "RUB", "Российская Федерация", null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1420), null, null, "Рубль", 643 },
                    { 4, "KZT", "Республика Казахстан", null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1420), null, null, "Тенге", 398 },
                    { 5, "TRY", "Турция", null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1430), null, null, "Лира", 949 },
                    { 6, "AED", "Объедененные Арабские Эмираты", null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1430), null, null, "Дирхам", 784 },
                    { 7, "KGS", "Кыргызская Республика", null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1430), null, null, "Сом", 417 },
                    { 8, "TJS", "Республика Таджикистан", null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1430), null, null, "Сомони", 972 }
                });

            migrationBuilder.InsertData(
                table: "ExpenseType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(240), null, "Зарплата", null, "Зарплата" },
                    { 2, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(240), null, "Аванс", null, "Аванс" },
                    { 3, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(250), null, "Курерам за перевозку", null, "Курерам за перевозку" },
                    { 4, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(250), null, "Обед", null, "Обед" },
                    { 5, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(250), null, "Карзи Хасана", null, "Карзи Хасана" },
                    { 6, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(250), null, "Депозит", null, "Депозит" },
                    { 7, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(250), null, "За перевозку до филиала", null, "За перевозку до филиала" },
                    { 8, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(260), null, "За доставку до получателя", null, "За доставку до получателя" },
                    { 9, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(260), null, "За забор посылки", null, "За забор посылки" },
                    { 10, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(260), null, "За выкуп", null, "За выкуп" },
                    { 11, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(260), null, "Ковертация", null, "Ковертация" },
                    { 12, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(260), null, "Перевод", null, "Перевод" },
                    { 13, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(260), null, "За мелкие расходы", null, "За мелкие расходы" }
                });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Cost", "CreatedBy", "DateCreated", "DateUpdated", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 7m, null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1400), null, "Description", null, "Стандарт" },
                    { 2, 12m, null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1400), null, "Description", null, "Экспресс" },
                    { 3, 30m, null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1400), null, "Description", null, "Ультра" },
                    { 5, 5m, null, new DateTime(2023, 3, 7, 22, 34, 32, 818, DateTimeKind.Local).AddTicks(1410), null, "Description", null, "Авто" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(20), null, "Создан", null, "Создан" },
                    { 2, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(60), null, "В пути", null, "В пути" },
                    { 3, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(60), null, "Прибыл в пункт доставки", null, "Прибыл" },
                    { 4, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(70), null, "На доставке у курьера", null, "У курьера" },
                    { 5, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(70), null, "Доставлен", null, "Доставлен" },
                    { 6, null, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(70), null, "Выдан", null, "Выдан" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Balance", "BranchId", "CreatedBy", "CurrencyId", "DateCreated", "DateUpdated", "ModifiedBy", "Name", "Number" },
                values: new object[,]
                {
                    { 1, 0m, 1, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(180), null, null, "Валютный счет Москвы", "643840USD" },
                    { 2, 0m, 1, null, 2, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(180), null, null, "Рублевый счет Москвы", "643643RUB" },
                    { 3, 0m, 2, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(180), null, null, "Валютный счет Ташкента", "860840USD" },
                    { 4, 0m, 2, null, 2, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(180), null, null, "Рублевый счет Ташкента", "860643RUB" },
                    { 5, 0m, 3, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(180), null, null, "Валютный счет Бишкека", "417840USD" },
                    { 6, 0m, 3, null, 2, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(190), null, null, "Рублевый счет Бишкека", "417643RUB" },
                    { 7, 0m, 4, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(190), null, null, "Валютный счет Душанбе", "972840USD" },
                    { 8, 0m, 4, null, 2, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(190), null, null, "Рублевый счет Душанбе", "972843RUB" },
                    { 9, 0m, 5, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(200), null, null, "Валютный счет Алматы", "398840USD" },
                    { 10, 0m, 5, null, 2, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(200), null, null, "Рублевый счет Алматы", "398643RUB" },
                    { 11, 0m, 6, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(200), null, null, "Валютный счет Стамбул", "792840USD" },
                    { 12, 0m, 6, null, 5, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(200), null, null, "Лировый счет Стамбул", "792949TRY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "CanGetAllBranches", "CanGetAllBranches", 1 },
                    { 2, "CanGetAllBranchesWithPagination", "CanGetAllBranchesWithPagination", 1 },
                    { 3, "CanGetBranchDetails", "CanGetBranchDetails", 1 },
                    { 4, "CanCreateBranch", "CanCreateBranch", 1 },
                    { 5, "CanUpdateBranch", "CanUpdateBranch", 1 },
                    { 6, "CanDeleteBranch", "CanDeleteBranch", 1 },
                    { 7, "CanDeleteBranches", "CanDeleteBranches", 1 },
                    { 8, "CanGetAllPlans", "CanGetAllPlans", 1 },
                    { 9, "CanGetAllPlansWithPagination", "CanGetAllPlansWithPagination", 1 },
                    { 10, "CanGetPlanDetails", "CanGetPlanDetails", 1 },
                    { 11, "CanCreatePlan", "CanCreatePlan", 1 },
                    { 12, "CanUpdatePlan", "CanUpdatePlan", 1 },
                    { 13, "CanDeletePlan", "CanDeletePlan", 1 },
                    { 14, "CanDeletePlans", "CanDeletePlans", 1 },
                    { 15, "CanGetAllStatuses", "CanGetAllStatuses", 1 },
                    { 16, "CanGetAllStatusesWithPagination", "CanGetAllStatusesWithPagination", 1 },
                    { 17, "CanGetStatusDetails", "CanGetStatusDetails", 1 },
                    { 18, "CanCreateStatus", "CanCreateStatus", 1 },
                    { 19, "CanUpdateStatus", "CanUpdateStatus", 1 },
                    { 20, "CanDeleteStatus", "CanDeleteStatus", 1 },
                    { 21, "CanDeleteStatuses", "CanDeleteStatuses", 1 },
                    { 22, "CanGetAllParcels", "CanGetAllParcels", 1 },
                    { 23, "CanGetAllParcelsWithPagination", "CanGetAllParcelsWithPagination", 1 },
                    { 24, "CanGetParcelDetails", "CanGetParcelDetails", 1 },
                    { 25, "CanCreateParcel", "CanCreateParcel", 1 },
                    { 26, "CanUpdateParcel", "CanUpdateParcel", 1 },
                    { 27, "CanDeleteParcel", "CanDeleteParcel", 1 },
                    { 28, "CanDeleteParcels", "CanDeleteParcels", 1 },
                    { 29, "CanGetAllUsers", "CanGetAllUsers", 1 },
                    { 30, "CanGetAllUsersWithPagination", "CanGetAllUsersWithPagination", 1 },
                    { 31, "CanGetUserDetails", "CanGetUserDetails", 1 },
                    { 32, "CanCreateUser", "CanCreateUser", 1 },
                    { 33, "CanUpdateUser", "CanUpdateUser", 1 },
                    { 34, "CanDeleteUser", "CanDeleteUser", 1 },
                    { 35, "CanDeleteUsers", "CanDeleteUsers", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "Balance", "CreatedBy", "CurrencyId", "DateCreated", "DateUpdated", "ModifiedBy", "Name", "Number", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 1, 0m, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(220), null, null, "Валютный счет", "30a8f9cc-840USD", "1", null },
                    { 2, 0m, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(220), null, null, "Валютный счет", "cadaa51d-840USD", "2", null },
                    { 3, 0m, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(220), null, null, "Валютный счет", "5a6f1681-840USD", "3", null },
                    { 4, 0m, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(230), null, null, "Валютный счет", "3b9d7f21-840USD", "1", null },
                    { 5, 0m, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(230), null, null, "Валютный счет", "0a1e5c27-840USD", "2", null },
                    { 6, 0m, null, 1, new DateTime(2023, 3, 7, 22, 34, 32, 786, DateTimeKind.Local).AddTicks(230), null, null, "Валютный счет", "e13b576b-840USD", "3", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_BranchId",
                table: "Account",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CurrencyId",
                table: "Account",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Id",
                table: "Account",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountHistory_BranchAccountId",
                table: "AccountHistory",
                column: "BranchAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHistory_CurrencyId",
                table: "AccountHistory",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHistory_Id",
                table: "AccountHistory",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountHistory_ParcelId",
                table: "AccountHistory",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHistory_PayerId1",
                table: "AccountHistory",
                column: "PayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id",
                table: "AspNetUsers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParcelJobId",
                table: "AspNetUsers",
                column: "ParcelJobId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branch_Id",
                table: "Branch",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_Id",
                table: "Currency",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Id",
                table: "Expenses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_Id",
                table: "Parcel",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelBranch_FromBranchId",
                table: "ParcelBranch",
                column: "FromBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelBranch_Id",
                table: "ParcelBranch",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelBranch_ParcelId",
                table: "ParcelBranch",
                column: "ParcelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelBranch_ToBranchId",
                table: "ParcelBranch",
                column: "ToBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelCost_CurrencyId",
                table: "ParcelCost",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelCost_Id",
                table: "ParcelCost",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelCost_ParcelId",
                table: "ParcelCost",
                column: "ParcelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelDescription_Id",
                table: "ParcelDescription",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelDescription_ParcelId",
                table: "ParcelDescription",
                column: "ParcelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelImage_Id",
                table: "ParcelImage",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelImage_ParcelId",
                table: "ParcelImage",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelItem_CurrencyId",
                table: "ParcelItem",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelItem_ParcelId",
                table: "ParcelItem",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelJob_Id",
                table: "ParcelJob",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelJob_ParcelId",
                table: "ParcelJob",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_Id",
                table: "ParcelOwners",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_ParcelId",
                table: "ParcelOwners",
                column: "ParcelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_RecepientCourierId1",
                table: "ParcelOwners",
                column: "RecepientCourierId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_RecepientId1",
                table: "ParcelOwners",
                column: "RecepientId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_RecepientStaffId1",
                table: "ParcelOwners",
                column: "RecepientStaffId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_SenderCourierId1",
                table: "ParcelOwners",
                column: "SenderCourierId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_SenderId1",
                table: "ParcelOwners",
                column: "SenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_SenderStaffId1",
                table: "ParcelOwners",
                column: "SenderStaffId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelPlan_Id",
                table: "ParcelPlan",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelPlan_ParcelId",
                table: "ParcelPlan",
                column: "ParcelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelPlan_PlanId",
                table: "ParcelPlan",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelSize_Id",
                table: "ParcelSize",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelSize_ParcelId",
                table: "ParcelSize",
                column: "ParcelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelSound_Id",
                table: "ParcelSound",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelSound_ParcelId",
                table: "ParcelSound",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelStatus_Id",
                table: "ParcelStatus",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelStatus_ParcelId",
                table: "ParcelStatus",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelStatus_StatusId",
                table: "ParcelStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Id",
                table: "Plan",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_Id",
                table: "Tokens",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_CurrencyId",
                table: "UserAccount",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_Id",
                table: "UserAccount",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_UserId1",
                table: "UserAccount",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountHistory_CurrencyId",
                table: "UserAccountHistory",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountHistory_Id",
                table: "UserAccountHistory",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountHistory_ParcelId",
                table: "UserAccountHistory",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountHistory_UserAccountId",
                table: "UserAccountHistory",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountHistory_UserId1",
                table: "UserAccountHistory",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountHistory");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpenseType");

            migrationBuilder.DropTable(
                name: "ParcelBranch");

            migrationBuilder.DropTable(
                name: "ParcelCost");

            migrationBuilder.DropTable(
                name: "ParcelDescription");

            migrationBuilder.DropTable(
                name: "ParcelImage");

            migrationBuilder.DropTable(
                name: "ParcelItem");

            migrationBuilder.DropTable(
                name: "ParcelOwners");

            migrationBuilder.DropTable(
                name: "ParcelPlan");

            migrationBuilder.DropTable(
                name: "ParcelSize");

            migrationBuilder.DropTable(
                name: "ParcelSound");

            migrationBuilder.DropTable(
                name: "ParcelStatus");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserAccountHistory");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "ParcelJob");

            migrationBuilder.DropTable(
                name: "Parcel");
        }
    }
}
