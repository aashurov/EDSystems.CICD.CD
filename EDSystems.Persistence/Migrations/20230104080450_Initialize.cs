using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EDSystems.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
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
                    UserId = table.Column<string>(type: "text", nullable: true),
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
                    RoleId = table.Column<string>(type: "text", nullable: false),
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
                    Id = table.Column<string>(type: "text", nullable: false),
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
                        name: "FK_AccountHistory_AspNetUsers_PayerId",
                        column: x => x.PayerId,
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
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
                    RecepientId = table.Column<string>(type: "text", nullable: true),
                    RecepientStaffId = table.Column<string>(type: "text", nullable: true),
                    SenderStaffId = table.Column<string>(type: "text", nullable: true),
                    RecepientCourierId = table.Column<string>(type: "text", nullable: true),
                    SenderCourierId = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_ParcelOwners_AspNetUsers_RecepientCourierId",
                        column: x => x.RecepientCourierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_RecepientId",
                        column: x => x.RecepientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_RecepientStaffId",
                        column: x => x.RecepientStaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_SenderCourierId",
                        column: x => x.SenderCourierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcelOwners_AspNetUsers_SenderStaffId",
                        column: x => x.SenderStaffId,
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
                        name: "FK_UserAccount_AspNetUsers_UserId",
                        column: x => x.UserId,
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
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccountHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
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
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "b78116c3-11d9-484c-b902-896a53fa6fe5", "Administrator", "ADMINISTRATOR" },
                    { "336b1b38-f4c9-4844-8dcb-b59a0d7f0533", "900de5e5-2fc9-4408-ba34-5df4fa2bd94b", "Customer", "CUSTOMER" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "76b8e705-d258-4dcd-868e-76e72227401d", "Courier", "COURIER" },
                    { "5919c97a-b888-4858-bbbe-0123a1952624", "a3477b20-80ad-4983-b32a-1fea3a04c8a8", "Staff", "STAFF" },
                    { "68373a2b-932e-4fff-a7a9-b31e156d4101", "00f37758-d12e-4706-928b-8f88a501745b", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ChatId", "ConcurrencyStamp", "DateCreated", "DateUpdated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParcelJobId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserNameT" },
                values: new object[,]
                {
                    { "0a1e5c27-0b09-4f60-a9c3-8618791a8672", 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "4dc3ba8f-b10a-405f-8849-6e60f4a84f45", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8049), null, "Ismoil@gmail.com", false, "EDTashkent", "Ismoil", false, null, "ISMOIL@GMAIL.COM", "ISMOIL", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "998977093262", false, "de9bbbe1-4263-47cc-9dfd-4d4ca1cd80ad", false, "ismoil", "UserName" },
                    { "11fafeb4-c7c1-463c-bb1e-55203e68dfdf", 0, "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", -1001663331836L, "90624d9b-aa72-48eb-ae91-187ce68146d2", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8194), null, "Umar@gmail.com", false, "EDMoscow", "Umar", false, null, "UMAR@GMAIL.COM", "UMAR", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "79963321030", false, "29a59dbf-02ff-4e55-939f-fea710e93cd9", false, "umar", "UserName" },
                    { "131d5dd1-6bf1-4f52-be90-00815000fb57", 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "679ab848-65ad-43c9-a1d6-9d6bdefd88db", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8071), null, "Khikmatillo@gmail.com", false, "EDTashkent", "Khikmatillo", false, null, "KHIKMATILLO@GMAIL.COM", "KHIKMATILLO", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "998974468090", false, "2ca5e2b1-98a3-4115-8969-703c0534afb3", false, "khikmatillo", "UserName" },
                    { "221c0048-08c9-4e72-8f5c-ddf4039f9488", 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "070c4151-d94e-4f08-805a-24a7a9790fb4", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8079), null, "Abbos@gmail.com", false, "EDTashkent", "Abbos", false, null, "ABBOS@GMAIL.COM", "ABBOS", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "998903550022", false, "25bc8988-3e39-4037-a765-fcaf30ec9324", false, "abbos", "UserName" },
                    { "30a8f9cc-8d37-4d93-ab2f-774428387e4a", 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "10f0a47d-d947-4ba1-b5ba-a0cba39bfe51", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8003), null, "administrator@gmail.com", false, "EDSystem", "Administrator", false, null, "ADMINISTRATOR@GMAIL.COM", "ADMINISTRATOR", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "998970000675", false, "82c6526a-149e-4860-8dc1-a6c07457eb7b", false, "administrator", "UserName" },
                    { "34a0eb9b-6797-40f7-a84c-aa31cdd4cdc6", 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "91855aa5-b3f9-4dee-9d30-771f29a65a46", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8065), null, "Ubaydulla@gmail.com", false, "EDTashkent", "Ubaydulla", false, null, "UBAYDULLA@GMAIL.COM", "UBAYDULLA", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "998990500033", false, "6b556a10-0876-4174-b036-5eb0e8ec3c5f", false, "ubaydulla", "UserName" },
                    { "3b9d7f21-1d66-4c98-8648-64a68777bccb", 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "25bcd5cb-7701-4db8-a14d-825a6caf2884", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8042), null, "Javohir@gmail.com", false, "EDTashkent", "Javohir", false, null, "JAVOHIR@GMAIL.COM", "JAVOHIR", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "998931710966", false, "33d48f21-ebd5-4a27-9a3a-b4c58afa7740", false, "javohir", "UserName" },
                    { "4ff7819d-8e17-4aa8-a0da-964c2db21591", 0, "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", -1001663331836L, "ff58b480-a157-4a17-8f16-345457e4def5", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8095), null, "Ulugbek@gmail.com", false, "EDMoscow", "Ulugbek", false, null, "ULUGBEK@GMAIL.COM", "ULUGBEK", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "79777403487", false, "ca31b94e-ca41-47fa-be8e-05755f8eee75", false, "ulugbek", "UserName" },
                    { "5a6f1681-c582-46f5-905b-4eb2c222dcf5", 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "6ba9f07a-bde3-43b6-9e40-d0d04bd94eff", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8035), null, "Nodir@gmail.com", false, "EDTashkent", "Nodir", false, null, "NODIR@GMAIL.COM", "NODIR", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "998909046605", false, "11b2a014-744a-43a1-8ed7-b221823b4697", false, "nodir", "UserName" },
                    { "92b7c777-0d3e-4026-844f-20164bb0f97e", 0, "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", -1001663331836L, "3dd44643-50b8-4748-870b-beb00462a781", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8200), null, "Abror@gmail.com", false, "EDMoscow", "Abror", false, null, "ABROR@GMAIL.COM", "ABROR", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "79296800899", false, "0a239918-aa15-4b65-a3fc-bdf6d907f471", false, "abror", "UserName" },
                    { "92db214d-cd73-4fbc-8b34-1dc0709ba0b2", 0, "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", -1001663331836L, "af435553-e30f-46a9-bb2b-3d0a946d5a94", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8101), null, "Abdulaziz@gmail.com", false, "EDMoscow", "Abdulaziz", false, null, "ABDULAZIZ@GMAIL.COM", "ABDULAZIZ", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "79691799000", false, "2381ef44-10c9-479f-9b86-c048d4dd1c41", false, "abdulaziz", "UserName" },
                    { "9c57fadd-110a-4b45-aa89-69aa141564c6", 0, "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", -1001663331836L, "cf8dcab0-9be2-4131-a4e0-281d710da1bc", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8108), null, "Doniyor@gmail.com", false, "EDMoscow", "Doniyor", false, null, "DONIYOR@GMAIL.COM", "DONIYOR", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "79777601654", false, "38b2474a-9891-4778-9990-cf9c779d6ddf", false, "doniyor", "UserName" },
                    { "cadaa51d-ddb3-4564-a8c5-79e80c98a032", 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "8847ac0c-c6df-431f-9488-991f7049b978", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8026), null, "hayrulloh@gmail.com", false, "EDTashkent", "Hayrulloh", false, null, "HAYRULLOH@GMAIL.COM", "HAYRULLOH", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "998935788886", false, "1a872252-a5bd-44bb-87fc-a84a71effba3", false, "hayrulloh", "UserName" },
                    { "e0c3bef9-fd70-421e-b07b-055c38b6d77c", 0, "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", -1001663331836L, "a88abf9c-2538-4df0-ad2a-7d0398e8de3d", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8086), null, "Shohruh@gmail.com", false, "EDMoscow", "Shohruh", false, null, "SHOHRUH@GMAIL.COM", "SHOHRUH", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "79060470085", false, "cb3afab8-4ee5-42ab-8354-64d27033c25c", false, "shohruh", "UserName" },
                    { "e13b576b-afbe-4b4c-aaad-64fd9bee3852", 0, "Республика Узбекистан, г. Ташкент, Кашгар 11, 100099", -1001663331836L, "0235589c-cd85-48a5-8bcc-54520a5061cf", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8058), null, "Sadulla@gmail.com", false, "EDTashkent", "Sadulla", false, null, "SADULLA@GMAIL.COM", "SADULLA", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "998994885995", false, "72a970f1-235c-4d86-9752-99fd1a424789", false, "sadulla", "UserName" },
                    { "eb6a85b0-a7fb-4f8e-9bea-03825e6f020f", 0, "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", -1001663331836L, "3abe7d58-5dd3-4ab9-89b6-31ac025c1aa5", new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8186), null, "Shaxzod@gmail.com", false, "EDMoscow", "Shaxzod", false, null, "SHAXZOD@GMAIL.COM", "SHAXZOD", null, "AQAAAAIAAYagAAAAEDuYFUUOTZ01KYaRl/wNdeERuWD1OsU3wDmdUrmpZHcmAA+Pzp/y3N8yW6zU4RmADA==", "79163870009", false, "ebb30ea4-81ac-4f92-a7f3-51acaf63468d", false, "shaxzod", "UserName" }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Address", "City", "Code", "Country", "CreatedBy", "DateCreated", "DateUpdated", "Email", "ModifiedBy", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Российская Федерация, Московская область, г. Москва, Академический район, улица Винокурова 7/5, корпус 3, индекс 117449", "Москва", "643", "Россия", null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8662), null, "info@ethnologistics.asia", null, "Москва", "+765165498496" },
                    { 2, "Республика Узбекистан, г. Ташкент, Юнусабадский район, улица Кашгар 11,", "Ташкент", "860", "Узбекистан", null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8664), null, "info@ethnologistics.asia", null, "Ташкент", "+998984651" },
                    { 3, "Киргизия, Бишкек, Жибек-Жолу д 443/1", "Бишкек", "417", "Киргистан", null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8667), null, "info@ethnologistics.asia", null, "Бишкек", "+765165498496" },
                    { 4, "Душанбе 122", "Душанбе", "762", "Таджикистан", null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8668), null, "info@ethnologistics.asia", null, "Душанбе", "+665165498496" },
                    { 5, "Алматы 123", "Алматы", "398", "Казахстан", null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8670), null, "info@ethnologistics.asia", null, "Алматы", "+665165498496" },
                    { 6, "Хайдарпашша", "Стамбул", "792", "Турция", null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8671), null, "info@ethnologistics.asia", null, "Стамбул", "+665165498496" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code", "Country", "CreatedBy", "DateCreated", "DateUpdated", "ModifiedBy", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "USD", "Соединенные Штаты Америки", null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8377), null, null, "Доллар", 840 },
                    { 2, "UZS", "Республика Узбекистан", null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8379), null, null, "Сум", 860 },
                    { 3, "RUB", "Российская Федерация", null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8380), null, null, "Рубль", 643 },
                    { 4, "KZT", "Республика Казахстан", null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8381), null, null, "Тенге", 398 },
                    { 5, "TRY", "Турция", null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8384), null, null, "Лира", 949 },
                    { 6, "AED", "Объедененные Арабские Эмираты", null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8385), null, null, "Дирхам", 784 },
                    { 7, "KGS", "Кыргызская Республика", null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8386), null, null, "Сом", 417 },
                    { 8, "TJS", "Республика Таджикистан", null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8387), null, null, "Сомони", 972 }
                });

            migrationBuilder.InsertData(
                table: "ExpenseType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8776), null, "Зарплата", null, "Зарплата" },
                    { 2, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8777), null, "Аванс", null, "Аванс" },
                    { 3, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8778), null, "Курерам за перевозку", null, "Курерам за перевозку" },
                    { 4, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8780), null, "Обед", null, "Обед" },
                    { 5, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8781), null, "Карзи Хасана", null, "Карзи Хасана" },
                    { 6, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8782), null, "Депозит", null, "Депозит" },
                    { 7, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8783), null, "За перевозку до филиала", null, "За перевозку до филиала" },
                    { 8, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8784), null, "За доставку до получателя", null, "За доставку до получателя" },
                    { 9, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8785), null, "За забор посылки", null, "За забор посылки" },
                    { 10, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8786), null, "За выкуп", null, "За выкуп" },
                    { 11, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8787), null, "Ковертация", null, "Ковертация" },
                    { 12, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8788), null, "Перевод", null, "Перевод" },
                    { 13, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8789), null, "За мелкие расходы", null, "За мелкие расходы" }
                });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Cost", "CreatedBy", "DateCreated", "DateUpdated", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 7m, null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8339), null, "Description", null, "Стандарт" },
                    { 2, 12m, null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8343), null, "Description", null, "Экспресс" },
                    { 3, 30m, null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8344), null, "Description", null, "Ультра" },
                    { 5, 5m, null, new DateTime(2023, 1, 4, 13, 4, 50, 371, DateTimeKind.Local).AddTicks(8346), null, "Description", null, "Авто" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8495), null, "Создан", null, "Создан" },
                    { 2, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8508), null, "В пути", null, "В пути" },
                    { 3, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8509), null, "Прибыл в пункт доставки", null, "Прибыл" },
                    { 4, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8510), null, "На доставке у курьера", null, "У курьера" },
                    { 5, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8511), null, "Доставлен", null, "Доставлен" },
                    { 6, null, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8512), null, "Выдан", null, "Выдан" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Balance", "BranchId", "CreatedBy", "CurrencyId", "DateCreated", "DateUpdated", "ModifiedBy", "Name", "Number" },
                values: new object[,]
                {
                    { 1, 0m, 1, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8688), null, null, "Валютный счет Москвы", "643840USD" },
                    { 2, 0m, 1, null, 2, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8691), null, null, "Рублевый счет Москвы", "643643RUB" },
                    { 3, 0m, 2, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8693), null, null, "Валютный счет Ташкента", "860840USD" },
                    { 4, 0m, 2, null, 2, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8694), null, null, "Рублевый счет Ташкента", "860643RUB" },
                    { 5, 0m, 3, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8696), null, null, "Валютный счет Бишкека", "417840USD" },
                    { 6, 0m, 3, null, 2, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8697), null, null, "Рублевый счет Бишкека", "417643RUB" },
                    { 7, 0m, 4, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8698), null, null, "Валютный счет Душанбе", "972840USD" },
                    { 8, 0m, 4, null, 2, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8699), null, null, "Рублевый счет Душанбе", "972843RUB" },
                    { 9, 0m, 5, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8700), null, null, "Валютный счет Алматы", "398840USD" },
                    { 10, 0m, 5, null, 2, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8702), null, null, "Рублевый счет Алматы", "398643RUB" },
                    { 11, 0m, 6, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8703), null, null, "Валютный счет Стамбул", "792840USD" },
                    { 12, 0m, 6, null, 5, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8704), null, null, "Лировый счет Стамбул", "792949TRY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "Discriminator", "UserId" },
                values: new object[,]
                {
                    { 1, "CanAddBranch", "CanAddBranch", "UserClaim", "30a8f9cc-8d37-4d93-ab2f-774428387e4a" },
                    { 2, "Manager", "CanOnlyRead", "UserClaim", "cadaa51d-ddb3-4564-a8c5-79e80c98a032" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "0a1e5c27-0b09-4f60-a9c3-8618791a8672" },
                    { "68373a2b-932e-4fff-a7a9-b31e156d4101", "11fafeb4-c7c1-463c-bb1e-55203e68dfdf" },
                    { "68373a2b-932e-4fff-a7a9-b31e156d4101", "131d5dd1-6bf1-4f52-be90-00815000fb57" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "221c0048-08c9-4e72-8f5c-ddf4039f9488" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "30a8f9cc-8d37-4d93-ab2f-774428387e4a" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "34a0eb9b-6797-40f7-a84c-aa31cdd4cdc6" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "3b9d7f21-1d66-4c98-8648-64a68777bccb" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "4ff7819d-8e17-4aa8-a0da-964c2db21591" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "5a6f1681-c582-46f5-905b-4eb2c222dcf5" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "92b7c777-0d3e-4026-844f-20164bb0f97e" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "92db214d-cd73-4fbc-8b34-1dc0709ba0b2" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "9c57fadd-110a-4b45-aa89-69aa141564c6" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "cadaa51d-ddb3-4564-a8c5-79e80c98a032" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "e0c3bef9-fd70-421e-b07b-055c38b6d77c" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "e13b576b-afbe-4b4c-aaad-64fd9bee3852" },
                    { "401bc2e9-3a0b-4281-9685-d6b36fc37d31", "eb6a85b0-a7fb-4f8e-9bea-03825e6f020f" }
                });

            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "Balance", "CreatedBy", "CurrencyId", "DateCreated", "DateUpdated", "ModifiedBy", "Name", "Number", "UserId" },
                values: new object[,]
                {
                    { 1, 0m, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8727), null, null, "Валютный счет", "30a8f9cc-840USD", "30a8f9cc-8d37-4d93-ab2f-774428387e4a" },
                    { 2, 0m, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8729), null, null, "Валютный счет", "cadaa51d-840USD", "cadaa51d-ddb3-4564-a8c5-79e80c98a032" },
                    { 3, 0m, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8731), null, null, "Валютный счет", "5a6f1681-840USD", "5a6f1681-c582-46f5-905b-4eb2c222dcf5" },
                    { 4, 0m, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8732), null, null, "Валютный счет", "3b9d7f21-840USD", "3b9d7f21-1d66-4c98-8648-64a68777bccb" },
                    { 5, 0m, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8733), null, null, "Валютный счет", "0a1e5c27-840USD", "0a1e5c27-0b09-4f60-a9c3-8618791a8672" },
                    { 6, 0m, null, 1, new DateTime(2023, 1, 4, 13, 4, 50, 311, DateTimeKind.Local).AddTicks(8734), null, null, "Валютный счет", "e13b576b-840USD", "e13b576b-afbe-4b4c-aaad-64fd9bee3852" }
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
                name: "IX_AccountHistory_PayerId",
                table: "AccountHistory",
                column: "PayerId");

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
                name: "IX_ParcelOwners_RecepientCourierId",
                table: "ParcelOwners",
                column: "RecepientCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_RecepientId",
                table: "ParcelOwners",
                column: "RecepientId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_RecepientStaffId",
                table: "ParcelOwners",
                column: "RecepientStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_SenderCourierId",
                table: "ParcelOwners",
                column: "SenderCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_SenderId",
                table: "ParcelOwners",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwners_SenderStaffId",
                table: "ParcelOwners",
                column: "SenderStaffId");

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
                name: "IX_UserAccount_UserId",
                table: "UserAccount",
                column: "UserId");

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
                name: "IX_UserAccountHistory_UserId",
                table: "UserAccountHistory",
                column: "UserId");
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
