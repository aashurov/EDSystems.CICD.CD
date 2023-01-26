using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDSystems.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class myMigration01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "86931cca-93a9-4d23-94ed-7648594dbcda");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "336b1b38-f4c9-4844-8dcb-b59a0d7f0533",
                column: "ConcurrencyStamp",
                value: "03d6492f-d488-4b62-bc94-c9b982593f7f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401bc2e9-3a0b-4281-9685-d6b36fc37d31",
                column: "ConcurrencyStamp",
                value: "25dd939f-03c9-4ff6-9a02-f05eda01664a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5919c97a-b888-4858-bbbe-0123a1952624",
                column: "ConcurrencyStamp",
                value: "73c901b0-26a9-4351-95df-824fc82a9ef9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68373a2b-932e-4fff-a7a9-b31e156d4101",
                column: "ConcurrencyStamp",
                value: "a1ca06a8-78ec-4a2a-bb2b-2bbcddc5fef7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a1e5c27-0b09-4f60-a9c3-8618791a8672",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "356f9e00-7a90-4a69-9599-279751fc2bbb", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(5680), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "4db9651d-6702-4cd7-99e0-b1e446cfbe4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11fafeb4-c7c1-463c-bb1e-55203e68dfdf",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d6d8604-7b64-4850-b5de-0c9574188852", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7210), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "d6ce6628-627d-4951-9628-f9a8c14f4a35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "131d5dd1-6bf1-4f52-be90-00815000fb57",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f87e2ad-04e9-41fc-b2a3-7ce35d683ad9", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(5730), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "22757420-a20c-4a53-bfdd-0689d7ba192b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "221c0048-08c9-4e72-8f5c-ddf4039f9488",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad31512d-f2f4-48aa-b293-c37f55486174", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(5930), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "43d897b0-c1b1-47cd-a912-0eb015e84535" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a8f9cc-8d37-4d93-ab2f-774428387e4a",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e36f5b3-39b4-44b8-8b91-c49146f6b790", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(5210), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "1e2c3f61-f858-47f6-9df2-3fb4cf5c4650" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34a0eb9b-6797-40f7-a84c-aa31cdd4cdc6",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6d64b32-4726-4041-bfa8-d3f1859aa70e", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(5720), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "7351a8f9-a2bc-4380-8778-43172014facf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b9d7f21-1d66-4c98-8648-64a68777bccb",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75dcc7fa-99ce-49c1-a420-798d958b42ee", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(5650), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "3005b877-7645-437e-87ee-70787241f668" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ff7819d-8e17-4aa8-a0da-964c2db21591",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e460b65-284a-4106-af45-f1c7c0aaab8e", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7160), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "db7f5eea-5cd3-407f-8d0f-c928cc6b74ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a6f1681-c582-46f5-905b-4eb2c222dcf5",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "194917f3-6ab4-45e3-b0dd-069511675a0a", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(5630), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "1067df9b-92f3-40a0-9e29-7f5e80c21579" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92b7c777-0d3e-4026-844f-20164bb0f97e",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2920a339-0f92-42a5-8c80-7835a158a60a", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7240), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "ac64ae7c-2f10-4391-8533-708460a4da92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92db214d-cd73-4fbc-8b34-1dc0709ba0b2",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3448cf4b-ef2a-4204-87b9-8493a2961a1c", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7170), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "e0e7d5ed-7ced-4444-8402-0d3ebbc8963e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c57fadd-110a-4b45-aa89-69aa141564c6",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dabb423-8bff-4cd8-817a-21fd3430c6b8", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7180), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "8c022c45-a8d9-4183-ba60-29e06e4979c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cadaa51d-ddb3-4564-a8c5-79e80c98a032",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70cabda6-975a-4077-88cf-426efd473c0b", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(5430), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "3b338ad8-2318-4fde-8ff4-c18da1d0d8e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0c3bef9-fd70-421e-b07b-055c38b6d77c",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "914fc971-8ed8-4397-bebd-c848cdc5f8fc", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7110), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "16048597-8db8-40e6-8eab-d52951bba337" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e13b576b-afbe-4b4c-aaad-64fd9bee3852",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54515182-b527-43ae-8f92-16133e8968e8", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(5690), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "2f5872d7-12f6-44b1-a1ef-ead46861be0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb6a85b0-a7fb-4f8e-9bea-03825e6f020f",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c584f918-7f8f-49ec-825d-056b43d47748", new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7190), "AQAAAAIAAYagAAAAEPWLHJ4Kp8eNE+/Lc/TL2qt9dbvHMfOC5daPiZVY7a/It3/Y0sb9fG1YFO5FDuZHBQ==", "2f329f18-ff9a-4194-9e35-d9482fe2378a" });

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 804, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 32, 10, 728, DateTimeKind.Local).AddTicks(6820));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5e6ce426-367c-4af9-a1b3-ddbfb2e5845d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "336b1b38-f4c9-4844-8dcb-b59a0d7f0533",
                column: "ConcurrencyStamp",
                value: "ab370926-428c-40ec-8e1a-e51b8b3ad6a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401bc2e9-3a0b-4281-9685-d6b36fc37d31",
                column: "ConcurrencyStamp",
                value: "cff8a6f4-f441-4e48-b54d-083c48d0dd45");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5919c97a-b888-4858-bbbe-0123a1952624",
                column: "ConcurrencyStamp",
                value: "e64c8340-0784-4c22-88cb-3c3520a2ec7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68373a2b-932e-4fff-a7a9-b31e156d4101",
                column: "ConcurrencyStamp",
                value: "d01f2334-0304-4041-be4f-465d15ffbcc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a1e5c27-0b09-4f60-a9c3-8618791a8672",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efd2401f-be30-466f-a9a0-8f6e657cea2e", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9675), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "8b12ef1c-5ba5-42c3-accc-cefc292f755e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11fafeb4-c7c1-463c-bb1e-55203e68dfdf",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e49bdb7-c9e8-4e90-b0fc-7b65ccfdf31b", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9816), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "f63872fd-9772-4238-a385-96ed3a1bacab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "131d5dd1-6bf1-4f52-be90-00815000fb57",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "089bc95e-80c3-4720-a259-dab3b94b2c3b", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9761), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "b7451705-5a63-4654-8ece-c3835400bc85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "221c0048-08c9-4e72-8f5c-ddf4039f9488",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd48d38f-010d-4bd3-8d75-bc378a5aa73a", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9771), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "db97a05c-d412-4b58-bbc1-98a0b367e9fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a8f9cc-8d37-4d93-ab2f-774428387e4a",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae10cd49-7c00-4a51-ba88-d84bc2c7f9b9", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9635), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "7f5db097-3ca5-4cd3-9f4a-67b90a64ff98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34a0eb9b-6797-40f7-a84c-aa31cdd4cdc6",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9980e704-c96f-4050-80b0-5e18f2d6d1a0", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9754), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "69817238-ecd9-4eba-b140-9b42330f8765" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b9d7f21-1d66-4c98-8648-64a68777bccb",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5419253-22e3-4955-a562-1f075cf9fc22", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9668), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "fb47769b-29b6-4d71-9bec-644797269810" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ff7819d-8e17-4aa8-a0da-964c2db21591",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "892345d5-50d6-4a64-900b-fb225deb3a85", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9785), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "58a755b0-403b-4ed2-afff-4e75ca5b9ff4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a6f1681-c582-46f5-905b-4eb2c222dcf5",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf61f6da-e2bf-4779-9f79-22d5df6be136", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9660), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "5e8534c8-b98b-4ecf-bc0d-765213267e16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92b7c777-0d3e-4026-844f-20164bb0f97e",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79e551c8-6806-4b7f-ba98-1146d85df900", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9822), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "831843bb-f263-472b-b298-17c3dc02db92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92db214d-cd73-4fbc-8b34-1dc0709ba0b2",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27953b89-dcd8-4295-b5ac-b43ab8674080", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9794), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "ce229f03-2c55-4b58-99ba-7cc172ec2251" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c57fadd-110a-4b45-aa89-69aa141564c6",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84c809bd-b332-4b54-8285-7b2cac6239a3", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9801), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "b7a82653-54f6-4520-ae91-abd4ed98e194" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cadaa51d-ddb3-4564-a8c5-79e80c98a032",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d55bb73-6285-4d11-94b0-78547c42f031", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9653), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "1d948fc1-a6a8-4116-aeac-544d0368fcbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0c3bef9-fd70-421e-b07b-055c38b6d77c",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0461516-2bc5-466a-b14e-a7581473688e", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9778), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "3e5bb79c-abdd-4e5a-860c-98b45ac9ca10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e13b576b-afbe-4b4c-aaad-64fd9bee3852",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ac7c441-d396-44b9-8ae3-2acc284214b0", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9682), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "1f7117b5-a8e2-4a13-bd07-7c2ab65cc43b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb6a85b0-a7fb-4f8e-9bea-03825e6f020f",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e6777cb-e63d-474b-a59b-8802337d5063", new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9807), "AQAAAAIAAYagAAAAEFv7gkeNJbOM5ayBbdEofa6yCUaFv5cZOx0gdC/LrpbZrF3QuJUY8UMNpnc4f9kXoQ==", "d589d665-7845-4117-9106-527e738ad5b0" });

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 371, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 371, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 371, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 371, DateTimeKind.Local).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 371, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 371, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 371, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 371, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3722));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "Plan",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 370, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 1, 26, 10, 21, 29, 310, DateTimeKind.Local).AddTicks(3701));
        }
    }
}
