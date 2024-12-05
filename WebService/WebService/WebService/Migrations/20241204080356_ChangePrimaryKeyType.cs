using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebService.Migrations
{
    public partial class ChangePrimaryKeyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    category_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    department_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    location_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    material_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.material_id);
                });

            migrationBuilder.CreateTable(
                name: "Measure",
                columns: table => new
                {
                    measure_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    symbol = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => x.measure_id);
                });

            migrationBuilder.CreateTable(
                name: "Requirement_status",
                columns: table => new
                {
                    requi_status_id = table.Column<byte>(type: "tinyint", nullable: false),
                    status_name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Requirem__8F69E6AD82F8094D", x => x.requi_status_id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    role_ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    name = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    category = table.Column<short>(type: "smallint", nullable: true),
                    measure = table.Column<int>(type: "int", nullable: true),
                    location = table.Column<short>(type: "smallint", nullable: true),
                    material = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Item__357D4CF8B5359660", x => x.code);
                    table.ForeignKey(
                        name: "FK__Item__category__5AEE82B9",
                        column: x => x.category,
                        principalTable: "Category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Item__location__5CD6CB2B",
                        column: x => x.location,
                        principalTable: "Location",
                        principalColumn: "location_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Item__material__5DCAEF64",
                        column: x => x.material,
                        principalTable: "Material",
                        principalColumn: "material_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Item__measure__5BE2A6F2",
                        column: x => x.measure,
                        principalTable: "Measure",
                        principalColumn: "measure_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    acc_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    role = table.Column<short>(type: "smallint", nullable: false),
                    department = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__9A20D5547893F938", x => x.acc_id);
                    table.ForeignKey(
                        name: "FK__Account__departm__5070F446",
                        column: x => x.department,
                        principalTable: "Department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Account__role__4F7CD00D",
                        column: x => x.role,
                        principalTable: "Role",
                        principalColumn: "role_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    requi_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account = table.Column<short>(type: "smallint", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    responsable = table.Column<short>(type: "smallint", nullable: true),
                    requi_status = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Requirem__ED19C6D1474AF54F", x => x.requi_id);
                    table.ForeignKey(
                        name: "FK__Requireme__accou__628FA481",
                        column: x => x.account,
                        principalTable: "Account",
                        principalColumn: "acc_id");
                    table.ForeignKey(
                        name: "FK__Requireme__respo__6477ECF3",
                        column: x => x.responsable,
                        principalTable: "Account",
                        principalColumn: "acc_id");
                    table.ForeignKey(
                        name: "FK__Requireme__statu__6383C8BA",
                        column: x => x.status,
                        principalTable: "Requirement_status",
                        principalColumn: "requi_status_id");
                });

            migrationBuilder.CreateTable(
                name: "Concept",
                columns: table => new
                {
                    concept_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requi_id = table.Column<int>(type: "int", nullable: true),
                    suplly_code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    unts = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concept", x => x.concept_id);
                    table.ForeignKey(
                        name: "FK__Concept__requi_i__6754599E",
                        column: x => x.requi_id,
                        principalTable: "Requirement",
                        principalColumn: "requi_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Concept__suplly___68487DD7",
                        column: x => x.suplly_code,
                        principalTable: "Item",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_department",
                table: "Account",
                column: "department");

            migrationBuilder.CreateIndex(
                name: "IX_Account_role",
                table: "Account",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_Concept_requi_id",
                table: "Concept",
                column: "requi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Concept_suplly_code",
                table: "Concept",
                column: "suplly_code");

            migrationBuilder.CreateIndex(
                name: "UQ__Departme__72E12F1B76E0AE44",
                table: "Department",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_category",
                table: "Item",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_Item_location",
                table: "Item",
                column: "location");

            migrationBuilder.CreateIndex(
                name: "IX_Item_material",
                table: "Item",
                column: "material");

            migrationBuilder.CreateIndex(
                name: "IX_Item_measure",
                table: "Item",
                column: "measure");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_account",
                table: "Requirement",
                column: "account");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_responsable",
                table: "Requirement",
                column: "responsable");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_status",
                table: "Requirement",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "UQ__Role__72E12F1B76375EA3",
                table: "Role",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concept");

            migrationBuilder.DropTable(
                name: "Requirement");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Requirement_status");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Measure");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
