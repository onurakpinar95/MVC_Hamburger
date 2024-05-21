using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_Hamburger.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Menuler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icerik = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ResimYolu = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Ad = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Fiyat = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "EkstraMalzemeler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Fiyat = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkstraMalzemeler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EkstraMalzemeler_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToplamFiyat = table.Column<decimal>(type: "money", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    MenuAdedi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Siparisler_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparisler_Menuler_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menuler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparisEkstraMalzemeler",
                columns: table => new
                {
                    SiparisEkstraMalzemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkstraMalzemeID = table.Column<int>(type: "int", nullable: false),
                    SiparisID = table.Column<int>(type: "int", nullable: false),
                    EkstraMalzemeAdedi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisEkstraMalzemeler", x => x.SiparisEkstraMalzemeID);
                    table.ForeignKey(
                        name: "FK_SiparisEkstraMalzemeler_EkstraMalzemeler_EkstraMalzemeID",
                        column: x => x.EkstraMalzemeID,
                        principalTable: "EkstraMalzemeler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisEkstraMalzemeler_Siparisler_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparisler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "6be3e8f3-4757-4725-98b6-130e92ca679d", "Yonetici", "YONETICI" },
                    { 2, "235faa40-b64b-48e8-8a70-9038685c4ce4", "Musteri", "MUSTERI" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adres", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Istanbul", "edf712d1-747c-45c8-afcf-5cb734bebbcb", "deniz@admin.com", false, false, null, "DENIZ@ADMIN.COM", "DENIZ@ADMIN.COM", "AQAAAAIAAYagAAAAEDi2qWQQHf4mBbenliUsucZo2V1JUBFamFGrh46heho8oB0G6qaN+fND1dmOCq8mpw==", null, false, "fd9d8b71-3e2a-425c-ba3e-52d4484caab5", false, "deniz@admin.com" },
                    { 2, 0, "Istanbul", "8045a0ac-543b-4f71-846f-4a7352bc16b9", "cemre@admin.com", false, false, null, "CEMRE@ADMIN.COM", "CEMRE@ADMIN.COM", "AQAAAAIAAYagAAAAED5C/SzV3NKn4GpccavedaExV2bL224f9fkSOtQUbfUATu9GEHJ3KB93pcvKYJVEWA==", null, false, "b65fae0e-893b-43c0-83b9-4ded479de1ec", false, "cemre@admin.com" },
                    { 3, 0, "Istanbul", "229f3040-cb23-4a7d-926a-e490a3026277", "onur@admin.com", false, false, null, "ONUR@ADMIN.COM", "ONUR@ADMIN.COM", "AQAAAAIAAYagAAAAEKohXNax98FQl/UW1SOvy8LFDsHb/kPus9hKEsTWVU2KTs/NI4FtCi7njLwt0EszEQ==", null, false, "207f6093-6af8-43ae-8709-8dad493dd5da", false, "onur@admin.com" }
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriID", "KategoriAdi" },
                values: new object[,]
                {
                    { 1, "İçecek" },
                    { 2, "Tatlı" },
                    { 3, "Sos" },
                    { 4, "Çıtır Lezzetler" }
                });

            migrationBuilder.InsertData(
                table: "Menuler",
                columns: new[] { "ID", "Ad", "Fiyat", "Icerik", "ResimYolu" },
                values: new object[,]
                {
                    { 1, "Etli Barbeku Menü", 200m, "Etli Barbekü Burger, Patates Kızartması (Küçük),Kutu İçecek", "1_etlibarbeku_menu.png" },
                    { 2, "Big Burger Menü", 250m, "Big Burger, Patates Kızartması (Küçük), Kutu İçecek", "2_ozelbig_menu.png" },
                    { 3, "Süper Chicken Menü", 230m, "Süper Chicken Burger, Patates Kızartması (Küçük),Kutu İçecek, Soğan Halkası 6'lı", "8_superchicken_menu.png" },
                    { 4, "İkili Burger Menü", 380m, "Big Burger, Süper Chicken Burger,Patates Kızartması (Küçük), 1 L. İçecek", "5_ikiliburger.png" },
                    { 5, "Üçlü Whopper Burger Menü", 600m, "3X Whopper Burger,Patates Kızartması (Küçük), 1 L. İçecek", "3_3luwhopper.png" },
                    { 6, "Üçlü Burger Menü", 550m, "3X Süper Chicken Burger, Patates Kızartması (Küçük), 1 L. İçecek", "7_benimuclum.png" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "EkstraMalzemeler",
                columns: new[] { "ID", "Ad", "Fiyat", "KategoriID" },
                values: new object[,]
                {
                    { 1, "Sos İstemiyorum", 0m, 3 },
                    { 2, "Ketçap", 10m, 3 },
                    { 3, "Mayonez", 10m, 3 },
                    { 4, "Hardal", 10m, 3 },
                    { 5, "Barbekü", 10m, 3 },
                    { 6, "Coca Cola", 0m, 1 },
                    { 7, "Fanta", 0m, 1 },
                    { 8, "Sprite", 0m, 1 },
                    { 9, "Ice Tea", 0m, 1 },
                    { 10, "Ayran", 0m, 1 },
                    { 11, "Su", 0m, 1 },
                    { 12, "Soda", 0m, 1 },
                    { 13, "Limonata", 0m, 1 },
                    { 14, "Ekstra Çıtır Lezzet Istemiyorum", 0m, 4 },
                    { 15, "Soğan Halkası 6'lı", 30m, 4 },
                    { 16, "Soğan Halkası 12'li", 50m, 4 },
                    { 17, "Nugget 6'lı", 40m, 4 },
                    { 18, "Nugget 12'li", 60m, 4 },
                    { 19, "Ekstra Tatlı Istemiyorum", 0m, 2 },
                    { 20, "Sufle", 40m, 2 },
                    { 21, "Donut", 30m, 2 },
                    { 22, "Dondurma", 20m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EkstraMalzemeler_KategoriID",
                table: "EkstraMalzemeler",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisEkstraMalzemeler_EkstraMalzemeID",
                table: "SiparisEkstraMalzemeler",
                column: "EkstraMalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisEkstraMalzemeler_SiparisID",
                table: "SiparisEkstraMalzemeler",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_MenuID",
                table: "Siparisler",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_UyeID",
                table: "Siparisler",
                column: "UyeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "SiparisEkstraMalzemeler");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EkstraMalzemeler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Menuler");
        }
    }
}
