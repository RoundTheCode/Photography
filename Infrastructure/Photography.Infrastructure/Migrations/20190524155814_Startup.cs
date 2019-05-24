using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Photography.Infrastructure.Migrations
{
    public partial class Startup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "photo");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hash = table.Column<string>(maxLength: 300, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Slug = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                schema: "photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hash = table.Column<string>(maxLength: 300, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enquiry",
                schema: "photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hash = table.Column<string>(maxLength: 300, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enquiry_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "photo",
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageAttribute",
                schema: "photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hash = table.Column<string>(maxLength: 300, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(maxLength: 400, nullable: true),
                    Extension = table.Column<string>(maxLength: 10, nullable: true),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Main = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageAttribute_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "photo",
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageCategory",
                schema: "photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hash = table.Column<string>(maxLength: 300, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Main = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "photo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageCategory_Image_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "photo",
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_ImageId",
                schema: "photo",
                table: "Enquiry",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageAttribute_ImageId",
                schema: "photo",
                table: "ImageAttribute",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCategory_CategoryId",
                schema: "photo",
                table: "ImageCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCategory_ImageId",
                schema: "photo",
                table: "ImageCategory",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enquiry",
                schema: "photo");

            migrationBuilder.DropTable(
                name: "ImageAttribute",
                schema: "photo");

            migrationBuilder.DropTable(
                name: "ImageCategory",
                schema: "photo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "photo");

            migrationBuilder.DropTable(
                name: "Image",
                schema: "photo");
        }
    }
}
