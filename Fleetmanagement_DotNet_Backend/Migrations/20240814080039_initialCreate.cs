using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fleetmanagementnew.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Customers ON");
            migrationBuilder.CreateTable(
                name: "AddOn",
                columns: table => new
                {
                    AddonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddonName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AddonDailyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RateValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOn", x => x.AddonId);
                });

            migrationBuilder.CreateTable(
                name: "Car_Type",
                columns: table => new
                {
                    CarTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarTypeName = table.Column<string>(name: "CarType_Name", type: "nvarchar(max)", nullable: false),
                    DailyRate = table.Column<double>(name: "Daily_Rate", type: "float", nullable: false),
                    WeeklyRate = table.Column<double>(name: "Weekly_Rate", type: "float", nullable: false),
                    MonthlyRate = table.Column<double>(name: "Monthly_Rate", type: "float", nullable: false),
                    ImagePath = table.Column<string>(name: "Image_Path", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_Type", x => x.CarTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreditCardType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DrivingLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdpNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedByDL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidThroughDL = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportValidThrough = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassportIssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassportIssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CEmailId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CMobileNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CAadharNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CPassNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RentalAmount = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    TotalAddonAmount = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HandoverDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    CarId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    PHubId = table.Column<long>(type: "bigint", nullable: false),
                    RHubId = table.Column<long>(type: "bigint", nullable: false),
                    isReturned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "Invoice_detail",
                columns: table => new
                {
                    IdetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    AddonId = table.Column<long>(type: "bigint", nullable: false),
                    Amt = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_detail", x => x.IdetailId);
                });

            migrationBuilder.CreateTable(
                name: "State_Master",
                columns: table => new
                {
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State_Master", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    bookingid = table.Column<long>(name: "booking_id", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingdate = table.Column<DateTime>(name: "booking_date", type: "datetime2", nullable: false),
                    startdate = table.Column<DateTime>(name: "start_date", type: "datetime2", nullable: false),
                    enddate = table.Column<DateTime>(name: "end_date", type: "datetime2", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dailyrate = table.Column<decimal>(name: "daily_rate", type: "decimal(18,2)", nullable: false),
                    weeklyrate = table.Column<decimal>(name: "weekly_rate", type: "decimal(18,2)", nullable: false),
                    monthlyrate = table.Column<decimal>(name: "monthly_rate", type: "decimal(18,2)", nullable: false),
                    EmailID = table.Column<string>(name: "Email_ID", type: "nvarchar(max)", nullable: false),
                    phubId = table.Column<long>(name: "p_hubId", type: "bigint", nullable: false),
                    rhubId = table.Column<long>(name: "r_hubId", type: "bigint", nullable: false),
                    custid = table.Column<long>(name: "cust_id", type: "bigint", nullable: false),
                    cartypeid = table.Column<long>(name: "cartype_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.bookingid);
                    table.ForeignKey(
                        name: "FK_booking_Car_Type_cartype_id",
                        column: x => x.cartypeid,
                        principalTable: "Car_Type",
                        principalColumn: "CarTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_Customers_cust_id",
                        column: x => x.custid,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City_Master",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateID = table.Column<long>(name: "State_ID", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City_Master", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Master_State_Master_State_ID",
                        column: x => x.StateID,
                        principalTable: "State_Master",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking_detail",
                columns: table => new
                {
                    bookingdetailid = table.Column<long>(name: "booking_detail_id", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingid = table.Column<long>(name: "booking_id", type: "bigint", nullable: false),
                    addonid = table.Column<long>(name: "addon_id", type: "bigint", nullable: false),
                    addonrate = table.Column<decimal>(name: "addon_rate", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_detail", x => x.bookingdetailid);
                    table.ForeignKey(
                        name: "FK_booking_detail_booking_booking_id",
                        column: x => x.bookingid,
                        principalTable: "booking",
                        principalColumn: "booking_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hubs",
                columns: table => new
                {
                    HubId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HubAddressandDetails = table.Column<string>(name: "Hub_Address_and_Details", type: "TEXT", nullable: false),
                    contactNumber = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hubs", x => x.HubId);
                    table.ForeignKey(
                        name: "FK_Hubs_City_Master_CityId",
                        column: x => x.CityId,
                        principalTable: "City_Master",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Hubs_State_Master_StateId",
                        column: x => x.StateId,
                        principalTable: "State_Master",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    AirportName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    HubId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                    table.ForeignKey(
                        name: "FK_Airports_City_Master_CityId",
                        column: x => x.CityId,
                        principalTable: "City_Master",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Airports_Hubs_HubId",
                        column: x => x.HubId,
                        principalTable: "Hubs",
                        principalColumn: "HubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Airports_State_Master_StateId",
                        column: x => x.StateId,
                        principalTable: "State_Master",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<long>(name: "Car_ID", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarTypeID = table.Column<long>(name: "CarType_ID", type: "bigint", nullable: false),
                    CarName = table.Column<string>(name: "Car_Name", type: "nvarchar(max)", nullable: false),
                    NumberPlate = table.Column<string>(name: "Number_Plate", type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<long>(type: "bigint", nullable: false),
                    Mileage = table.Column<double>(type: "float", nullable: false),
                    HubID = table.Column<long>(name: "Hub_ID", type: "bigint", nullable: false),
                    IsAvailable = table.Column<string>(name: "Is_Available", type: "char(1)", nullable: false),
                    MaintenanceDueDate = table.Column<DateTime>(name: "Maintenance_Due_Date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Car_Car_Type_CarType_ID",
                        column: x => x.CarTypeID,
                        principalTable: "Car_Type",
                        principalColumn: "CarTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Hubs_Hub_ID",
                        column: x => x.HubID,
                        principalTable: "Hubs",
                        principalColumn: "HubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CityId",
                table: "Airports",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_HubId",
                table: "Airports",
                column: "HubId");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_StateId",
                table: "Airports",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_cartype_id",
                table: "booking",
                column: "cartype_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_cust_id",
                table: "booking",
                column: "cust_id");

            migrationBuilder.CreateIndex(
                name: "IX_booking_detail_booking_id",
                table: "booking_detail",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarType_ID",
                table: "Car",
                column: "CarType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_Hub_ID",
                table: "Car",
                column: "Hub_ID");

            migrationBuilder.CreateIndex(
                name: "IX_City_Master_State_ID",
                table: "City_Master",
                column: "State_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_CityId",
                table: "Hubs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_StateId",
                table: "Hubs",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddOn");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "booking_detail");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Invoice_detail");

            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "Hubs");

            migrationBuilder.DropTable(
                name: "Car_Type");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "City_Master");

            migrationBuilder.DropTable(
                name: "State_Master");
        }
    }
}
