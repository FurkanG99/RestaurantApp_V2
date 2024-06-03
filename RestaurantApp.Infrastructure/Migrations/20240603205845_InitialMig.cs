using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Infrastructure.Migrations
{
    public partial class InitialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CapacitySlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlotDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCapacity = table.Column<int>(type: "int", nullable: false),
                    CurrentCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacitySlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndEvent = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.ShoppingCartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ChatUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_ChatUserId",
                        column: x => x.ChatUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "GalleryImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImagePaht = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryImages_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeopleCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    CapacitySlotId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reservations_CapacitySlots_CapacitySlotId",
                        column: x => x.CapacitySlotId,
                        principalTable: "CapacitySlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reservations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "CapacitySlots",
                columns: new[] { "Id", "CurrentCapacity", "SlotDate", "TotalCapacity" },
                values: new object[,]
                {
                    { 1, 94, new DateTime(2024, 6, 13, 20, 58, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 2, 94, new DateTime(2024, 6, 23, 20, 58, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 3, 94, new DateTime(2024, 7, 3, 20, 58, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 4, 94, new DateTime(2024, 7, 18, 20, 58, 0, 0, DateTimeKind.Unspecified), 100 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Starters" },
                    { 2, "Salads" },
                    { 3, "Specialty" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndEvent", "StartEvent", "Title" },
                values: new object[,]
                {
                    { 1, "Christmas Day", new DateTime(2024, 12, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Day" },
                    { 2, "Heppy New Year", new DateTime(2024, 12, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 20, 0, 0, 0, DateTimeKind.Unspecified), "Heppy New Year" },
                    { 3, "Easter Sunday", new DateTime(2024, 3, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 20, 0, 0, 0, DateTimeKind.Unspecified), "Easter Sunday" }
                });

            migrationBuilder.InsertData(
                table: "GalleryImages",
                columns: new[] { "Id", "ApplicationUserId", "Caption", "CreatedBy", "CreatedOn", "ImagePaht", "LikesCount", "ViewsCount" },
                values: new object[,]
                {
                    { 1, null, null, null, new DateTime(2024, 6, 3, 23, 58, 45, 495, DateTimeKind.Local).AddTicks(5350), "img/gallery/gallery-1.jpg", 0, 0 },
                    { 2, null, null, null, new DateTime(2024, 6, 2, 23, 58, 45, 495, DateTimeKind.Local).AddTicks(5351), "img/gallery/gallery-2.jpg", 0, 0 },
                    { 3, null, null, null, new DateTime(2024, 6, 1, 23, 58, 45, 495, DateTimeKind.Local).AddTicks(5353), "img/gallery/gallery-3.jpg", 0, 0 },
                    { 4, null, null, null, new DateTime(2024, 5, 31, 23, 58, 45, 495, DateTimeKind.Local).AddTicks(5354), "img/gallery/gallery-4.jpg", 0, 0 },
                    { 5, null, null, null, new DateTime(2024, 5, 30, 23, 58, 45, 495, DateTimeKind.Local).AddTicks(5355), "img/gallery/gallery-5.jpg", 0, 0 },
                    { 6, null, null, null, new DateTime(2024, 5, 29, 23, 58, 45, 495, DateTimeKind.Local).AddTicks(5355), "img/gallery/gallery-6.jpg", 0, 0 },
                    { 7, null, null, null, new DateTime(2024, 5, 28, 23, 58, 45, 495, DateTimeKind.Local).AddTicks(5356), "img/gallery/gallery-7.jpg", 0, 0 },
                    { 8, null, null, null, new DateTime(2024, 5, 27, 23, 58, 45, 495, DateTimeKind.Local).AddTicks(5358), "img/gallery/gallery-8.jpg", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "Price" },
                values: new object[,]
                {
                    { new Guid("9e3cdb70-6f53-4a89-ae00-639f5e265219"), 0m },
                    { new Guid("b574b35d-9fcb-4403-aca3-0feb4479804b"), 0m },
                    { new Guid("eaeca7c9-c81f-4d4a-aed6-8eae37e1460f"), 0m }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "TownName" },
                values: new object[] { 1, "London" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "PostalCode", "Street", "TownId" },
                values: new object[] { new Guid("553fb0ed-0384-4aeb-f80d-08dc21d76b67"), "NB12 JAT", "Baker Street", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 3, "Lorem, deren, trataro, filede, nerada", "img/menu/lobster-bisque.jpg", "Lobster Bisque", 5.95m },
                    { 2, 3, "Lorem, deren, trataro, filede, nerada", "img/menu/bread-barrel.jpg", "Bread Barrel", 6.95m },
                    { 3, 3, "A delicate crab cake served on a toasted roll with lettuce and tartar sauce\r\n", "img/menu/cake.jpg", "Crab Cake", 7.95m },
                    { 5, 2, "Grilled chicken with provolone, artichoke hearts, and roasted red pesto\r\n", "img/menu/tuscan-grilled.jpg", "Tuscan Grilled", 9.95m },
                    { 6, 1, "Lorem, deren, trataro, filede, nerada", "img/menu/mozzarella.jpg", "Mozzarella Stick", 4.95m },
                    { 7, 2, "Fresh spinach, crisp romaine, tomatoes, and Greek olives", "img/menu/greek-salad.jpg", "Greek Salad", 9.95m },
                    { 8, 2, "Fresh spinach with mushrooms, hard boiled egg, and warm bacon vinaigrette", "img/menu/spinach-salad.jpg", "Spinach Salad", 9.95m },
                    { 9, 3, "Plump lobster meat, mayo and crisp lettuce on a toasted bulky roll", "img/menu/lobster-roll.jpg", "Lobster Roll", 9.95m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirsName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e15c57a2-31a0-4cc1-8bd9-9f7cd398f3c9"), 0, new Guid("553fb0ed-0384-4aeb-f80d-08dc21d76b67"), "d0dfd922-6193-4fdc-b4e4-8258a7774ef0", "paul@gmail.com", true, "Paul", "Robinson", false, null, "PAUL@GMAIL.COM", "PAUL", "AQAAAAEAACcQAAAAEIQBckPO7NTtFndkJe6D+2oOXdxKl6FGxhpVbZeQ2jBl9ZoGo4UNaUrjjKuE51L5FA==", null, false, "9f78cc01-2633-4158-aed8-1ff9597dbc7b", new Guid("9e3cdb70-6f53-4a89-ae00-639f5e265219"), false, "paul" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirsName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd300f3c9"), 0, new Guid("553fb0ed-0384-4aeb-f80d-08dc21d76b67"), "1d9ae258-8ea0-4aa6-bcde-7c119f71b765", "john@gmail.com", true, "John", "Walker", false, null, "JOHN@GMAIL.COM", "JOHN", "AQAAAAEAACcQAAAAEGrjDNVmbEiugn+gMEF+KxvUYPDFce91aFo+wRxInEt6M195MSPvYIsgmu9XhDUsSA==", null, false, "dbad8b44-c787-4706-814a-a793c4bd79e4", new Guid("eaeca7c9-c81f-4d4a-aed6-8eae37e1460f"), false, "john" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirsName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShoppingCartId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd380f3c9"), 0, new Guid("553fb0ed-0384-4aeb-f80d-08dc21d76b67"), "609c4b4d-58d3-4db0-bb2f-0f21e9d35c72", "jack@gmail.com", true, "Jack", "Jackson", false, null, "JACK@GMAIL.COM", "JACK", "AQAAAAEAACcQAAAAEEAepzScwkDXWQEs/uNfJw3d9/VFnStA2TrXO51gmOhQe3nY5JuQhh8qbNnsseeUMA==", null, false, "cbcd9c84-b324-40a9-8f6e-e3322a00c091", new Guid("b574b35d-9fcb-4403-aca3-0feb4479804b"), false, "jack" });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "ApplicationUserId", "CapacitySlotId", "Date", "Description", "Email", "EventId", "FirstName", "LastName", "PeopleCount", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("11033ee5-418d-45a2-9128-26eba834163d"), new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd380f3c9"), 1, new DateTime(2024, 6, 13, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "jack@gmail.com", null, "Jack", "Jackson", 2, "07708064509" },
                    { new Guid("33cadf68-0ddc-4069-9d14-58b3586ab0e9"), new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd380f3c9"), 4, new DateTime(2024, 7, 18, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "jack@gmail.com", null, "Jack", "Jackson", 2, "07708064509" },
                    { new Guid("51b8b769-84e9-478b-9d73-1b1959dc51c0"), new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd300f3c9"), 4, new DateTime(2024, 7, 18, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "john@gmail.com", null, "John", "Walker", 2, "07708064509" },
                    { new Guid("5c948282-dc9c-47f7-b66c-267fa1b05eb4"), new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd300f3c9"), 1, new DateTime(2024, 6, 13, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "john@gmail.com", null, "John", "Walker", 2, "07708064509" },
                    { new Guid("a51c9bc3-12a9-4f84-9db7-46464edee771"), new Guid("e15c57a2-31a0-4cc1-8bd9-9f7cd398f3c9"), 1, new DateTime(2024, 6, 13, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "paul@gmail.com", null, "Paul", "Robinson", 2, "07708064509" },
                    { new Guid("b1d117ae-b732-467e-8f45-1166ec6c631e"), new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd380f3c9"), 2, new DateTime(2024, 6, 23, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "jack@gmail.com", null, "Jack", "Jackson", 2, "07708064509" },
                    { new Guid("c201d489-051f-4bff-94b2-b64cab069af0"), new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd300f3c9"), 3, new DateTime(2024, 7, 3, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "john@gmail.com", null, "John", "Walker", 2, "07708064509" },
                    { new Guid("c645413f-6ddb-48bb-a4ee-700a046cd299"), new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd380f3c9"), 3, new DateTime(2024, 7, 3, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "jack@gmail.com", null, "Jack", "Jackson", 2, "07708064509" },
                    { new Guid("ca2cfd10-944a-4edf-baea-822de9b484e2"), new Guid("e15c57a2-31a0-4cc1-8bd9-9f7cd398f3c9"), 3, new DateTime(2024, 7, 3, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "paul@gmail.com", null, "Paul", "Robinson", 2, "07708064509" },
                    { new Guid("d2462d9c-1f12-4c88-a429-1ea22bbaf61f"), new Guid("e15c57a2-31a0-4cc1-8bd9-9f7cd398f3c9"), 2, new DateTime(2024, 6, 23, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "paul@gmail.com", null, "Paul", "Robinson", 2, "07708064509" },
                    { new Guid("eaf18063-0b6e-46f3-8c0a-39c1c27689d5"), new Guid("e15c57a2-31a0-4cc1-8bd9-9f7cd398f3c9"), 4, new DateTime(2024, 7, 18, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "paul@gmail.com", null, "Paul", "Robinson", 2, "07708064509" },
                    { new Guid("fe028d45-3e06-4a0e-986a-d32f79956623"), new Guid("e15c76a2-31a0-4cc1-8bd9-9f7cd300f3c9"), 2, new DateTime(2024, 6, 23, 20, 58, 0, 0, DateTimeKind.Unspecified), null, "john@gmail.com", null, "John", "Walker", 2, "07708064509" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TownId",
                table: "Addresses",
                column: "TownId");

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
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShoppingCartId",
                table: "AspNetUsers",
                column: "ShoppingCartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatId",
                table: "ChatMessages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ChatUserId",
                table: "Chats",
                column: "ChatUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryImages_ApplicationUserId",
                table: "GalleryImages",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CapacitySlotId",
                table: "Reservations",
                column: "CapacitySlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EventId",
                table: "Reservations",
                column: "EventId");
        }

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
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "GalleryImages");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CapacitySlots");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
