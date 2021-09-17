using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace agoravai.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<long>(type: "INTEGER", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar (15)", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    Picture = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "nchar (5)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar (40)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar (60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar (24)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar (24)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(type: "INTEGER", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar (20)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar (10)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    TitleOfCourtesy = table.Column<string>(type: "nvarchar (25)", nullable: true),
                    BirthDate = table.Column<byte[]>(type: "datetime", nullable: true),
                    HireDate = table.Column<byte[]>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "nvarchar (60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar (24)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar (4)", nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true),
                    Notes = table.Column<string>(type: "ntext", nullable: true),
                    ReportsTo = table.Column<long>(type: "int", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar (255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTerritories",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(type: "int", nullable: false),
                    TerritoryID = table.Column<string>(type: "nvarchar", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperID = table.Column<long>(type: "INTEGER", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar (40)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar (24)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<long>(type: "INTEGER", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar (40)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar (30)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar (60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar (24)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar (24)", nullable: true),
                    HomePage = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    TerritoryID = table.Column<string>(type: "nvarchar", nullable: false),
                    TerritoryDescription = table.Column<string>(type: "nchar", nullable: false),
                    RegionID = table.Column<long>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "INTEGER", nullable: false),
                    CustomerID = table.Column<string>(type: "nchar (5)", nullable: true),
                    EmployeeID = table.Column<long>(type: "int", nullable: true),
                    OrderDate = table.Column<byte[]>(type: "datetime", nullable: true),
                    RequiredDate = table.Column<byte[]>(type: "datetime", nullable: true),
                    ShippedDate = table.Column<byte[]>(type: "datetime", nullable: true),
                    ShipVia = table.Column<long>(type: "int", nullable: true),
                    Freight = table.Column<byte[]>(type: "money", nullable: true, defaultValueSql: "0"),
                    ShipName = table.Column<string>(type: "nvarchar (40)", nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar (60)", nullable: true),
                    ShipCity = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    ShipRegion = table.Column<string>(type: "nvarchar (15)", nullable: true),
                    ShipPostalCode = table.Column<string>(type: "nvarchar (10)", nullable: true),
                    ShipCountry = table.Column<string>(type: "nvarchar (15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Shippers_ShipVia",
                        column: x => x.ShipVia,
                        principalTable: "Shippers",
                        principalColumn: "ShipperID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<long>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar (40)", nullable: false),
                    SupplierID = table.Column<long>(type: "int", nullable: true),
                    CategoryID = table.Column<long>(type: "int", nullable: true),
                    QuantityPerUnit = table.Column<string>(type: "nvarchar (20)", nullable: true),
                    UnitPrice = table.Column<byte[]>(type: "money", nullable: true, defaultValueSql: "0"),
                    UnitsInStock = table.Column<long>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    UnitsOnOrder = table.Column<long>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    ReorderLevel = table.Column<long>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    Discontinued = table.Column<byte[]>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order Details",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "int", nullable: false),
                    ProductID = table.Column<long>(type: "int", nullable: false),
                    UnitPrice = table.Column<byte[]>(type: "money", nullable: false, defaultValueSql: "0"),
                    Quantity = table.Column<long>(type: "smallint", nullable: false, defaultValueSql: "1"),
                    Discount = table.Column<double>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order Details", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Order Details_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order Details_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "CategoryName",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "City",
                table: "Customers",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "CompanyNameCustomers",
                table: "Customers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCodeCustomers",
                table: "Customers",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "Region",
                table: "Customers",
                column: "Region");

            migrationBuilder.CreateIndex(
                name: "LastName",
                table: "Employees",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "PostalCodeEmployees",
                table: "Employees",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "OrderID",
                table: "Order Details",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "OrdersOrder_Details",
                table: "Order Details",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "ProductID",
                table: "Order Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "ProductsOrder_Details",
                table: "Order Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "CustomersOrders",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "EmployeesOrders",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "OrderDate",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "ShippedDate",
                table: "Orders",
                column: "ShippedDate");

            migrationBuilder.CreateIndex(
                name: "ShippersOrders",
                table: "Orders",
                column: "ShipVia");

            migrationBuilder.CreateIndex(
                name: "ShipPostalCode",
                table: "Orders",
                column: "ShipPostalCode");

            migrationBuilder.CreateIndex(
                name: "CategoriesProducts",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "SupplierID",
                table: "Products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "SuppliersProducts",
                table: "Products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "CompanyNameSuppliers",
                table: "Suppliers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCodeSuppliers",
                table: "Suppliers",
                column: "PostalCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTerritories");

            migrationBuilder.DropTable(
                name: "Order Details");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
