using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepaway.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CounselorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.CabinId);
                });

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    CamperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.CamperId);
                });

            migrationBuilder.CreateTable(
                name: "Counselors",
                columns: table => new
                {
                    CounselorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsActive = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counselors", x => x.CounselorId);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    NextOfKinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.NextOfKinId);
                });

            migrationBuilder.CreateTable(
                name: "CabinCamper",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false),
                    CamperId = table.Column<int>(type: "int", nullable: false),
                    EnterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinCamper", x => new { x.CabinId, x.CamperId });
                    table.ForeignKey(
                        name: "FK_CabinCamper_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "CabinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinCamper_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "CamperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinCounselor",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false),
                    CounselorId = table.Column<int>(type: "int", nullable: false),
                    EnterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinCounselor", x => new { x.CabinId, x.CounselorId });
                    table.ForeignKey(
                        name: "FK_CabinCounselor_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "CabinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinCounselor_Counselors_CounselorId",
                        column: x => x.CounselorId,
                        principalTable: "Counselors",
                        principalColumn: "CounselorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CamperNextOfKin",
                columns: table => new
                {
                    CamperId = table.Column<int>(type: "int", nullable: false),
                    NextOfKinId = table.Column<int>(type: "int", nullable: false),
                    EnterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamperNextOfKin", x => new { x.CamperId, x.NextOfKinId });
                    table.ForeignKey(
                        name: "FK_CamperNextOfKin_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "CamperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CamperNextOfKin_NextOfKins_NextOfKinId",
                        column: x => x.NextOfKinId,
                        principalTable: "NextOfKins",
                        principalColumn: "NextOfKinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cabins",
                columns: new[] { "CabinId", "CounselorId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Sunny Woods cabin" },
                    { 2, 2, "Happy Raccoon cabin" },
                    { 3, 3, "Aqua Wilderness cabin" },
                    { 4, 4, "Green Country cabin" },
                    { 5, 5, "Grey Meadows cabin" },
                    { 6, 0, "Blue Outback cabin" }
                });

            migrationBuilder.InsertData(
                table: "Campers",
                columns: new[] { "CamperId", "Allergies", "FirstName", "SocialSecurityNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "null", "Jane", null, "Doe" },
                    { 2, "Peanuts", "John", null, "Doe" },
                    { 3, "null", "Denys", null, "Demetr" },
                    { 4, "null", "Queenie", null, "Penuzzi" },
                    { 5, "Dogs", "Grove", null, "Smith" },
                    { 6, "Cats", "Emye", null, "Overall" },
                    { 7, "null", "Wilton", null, "Florence" },
                    { 8, "Carrots", "Pamela", null, "Samples" },
                    { 9, "null", "Percy", null, "Smallcomb" },
                    { 10, "Sunlight", "Essy", null, "Piddocke" },
                    { 11, "Gluten", "Hannah", null, "Burnyate" },
                    { 12, "null", "Alia", null, "Wait" },
                    { 13, "null", "Eartha", null, "Florence" },
                    { 14, "Electricity", "Tybi", null, "Banbridge" },
                    { 15, "null", "Cecily", null, "Wavell" },
                    { 16, "null", "Welch", null, "Godspede" },
                    { 17, "null", "Arlene", null, "Wavell" },
                    { 18, "null", "Obediah", null, "Fitzpatrick" }
                });

            migrationBuilder.InsertData(
                table: "Counselors",
                columns: new[] { "CounselorId", "FirstName", "Phone", "SocialSecurityNumber", "Surname", "YearsActive" },
                values: new object[,]
                {
                    { 1, "Kym", null, null, "MacIlurick", "4" },
                    { 2, "Felice", null, null, "Balharry", null },
                    { 3, "Morgan", null, null, "Rex", null },
                    { 4, "Marion", null, null, "Currum", null },
                    { 5, "Cletus", null, null, "Cholomin", null }
                });

            migrationBuilder.InsertData(
                table: "NextOfKins",
                columns: new[] { "NextOfKinId", "FirstName", "Phone", "SocialSecurityNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "Andy", null, null, "Belmont" },
                    { 2, "Jaqueline", null, null, "Doe" },
                    { 3, "Jack", null, null, "Doe" },
                    { 4, "Genia", null, null, "Andresser" },
                    { 5, "Minny", null, null, "Roderigo" }
                });

            migrationBuilder.InsertData(
                table: "CabinCamper",
                columns: new[] { "CabinId", "CamperId", "EnterDate", "ExitDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 6, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 7, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CabinCounselor",
                columns: new[] { "CabinId", "CounselorId", "EnterDate", "ExitDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CamperNextOfKin",
                columns: new[] { "CamperId", "NextOfKinId", "EnterDate", "ExitDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabinCamper_CamperId",
                table: "CabinCamper",
                column: "CamperId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinCounselor_CounselorId",
                table: "CabinCounselor",
                column: "CounselorId");

            migrationBuilder.CreateIndex(
                name: "IX_CamperNextOfKin_NextOfKinId",
                table: "CamperNextOfKin",
                column: "NextOfKinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinCamper");

            migrationBuilder.DropTable(
                name: "CabinCounselor");

            migrationBuilder.DropTable(
                name: "CamperNextOfKin");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropTable(
                name: "Counselors");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "NextOfKins");
        }
    }
}