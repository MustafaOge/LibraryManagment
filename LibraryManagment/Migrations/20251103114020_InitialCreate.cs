using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryManagment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTHOR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FULL_NAME = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CREATED_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PUBLISHER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PUBLISHER_NAME = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CREATED_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLISHER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "READER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NATIONAL_ID = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    FULL_NAME = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ADDRESS = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IMAGE = table.Column<byte[]>(type: "bytea", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CREATED_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CREATED_BY = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_READER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FULL_NAME = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    USERNAME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TITLE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BOOK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BARCODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TITLE = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AUTHOR_ID = table.Column<int>(type: "integer", nullable: true),
                    PUBLISHER_ID = table.Column<int>(type: "integer", nullable: true),
                    BOOK_TYPE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    PRINT_LOCATION = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PRINT_NUMBER = table.Column<int>(type: "integer", nullable: true),
                    PRINT_DATE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ACQUISITION_TYPE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ACQUISITION_DATE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PAGE_COUNT = table.Column<int>(type: "integer", nullable: true),
                    IMAGE = table.Column<byte[]>(type: "bytea", nullable: false),
                    IS_LOANED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CREATED_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CREATED_BY = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOOK_AUTHOR_AUTHOR_ID",
                        column: x => x.AUTHOR_ID,
                        principalTable: "AUTHOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOOK_PUBLISHER_PUBLISHER_ID",
                        column: x => x.PUBLISHER_ID,
                        principalTable: "PUBLISHER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCredential",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredential", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCredential_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOAN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BOOK_ID = table.Column<int>(type: "integer", nullable: false),
                    READER_ID = table.Column<int>(type: "integer", nullable: false),
                    LOAN_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RETURN_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    STATUS = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CREATED_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CREATED_BY = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_DATE = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOAN_BOOK_BOOK_ID",
                        column: x => x.BOOK_ID,
                        principalTable: "BOOK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOAN_READER_READER_ID",
                        column: x => x.READER_ID,
                        principalTable: "READER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_AUTHOR_ID",
                table: "BOOK",
                column: "AUTHOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_BARCODE",
                table: "BOOK",
                column: "BARCODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_PUBLISHER_ID",
                table: "BOOK",
                column: "PUBLISHER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOAN_BOOK_ID",
                table: "LOAN",
                column: "BOOK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOAN_LOAN_DATE",
                table: "LOAN",
                column: "LOAN_DATE");

            migrationBuilder.CreateIndex(
                name: "IX_LOAN_READER_ID",
                table: "LOAN",
                column: "READER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_READER_NATIONAL_ID",
                table: "READER",
                column: "NATIONAL_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_USERNAME",
                table: "USER",
                column: "USERNAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCredential_UserId",
                table: "UserCredential",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOAN");

            migrationBuilder.DropTable(
                name: "UserCredential");

            migrationBuilder.DropTable(
                name: "BOOK");

            migrationBuilder.DropTable(
                name: "READER");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "AUTHOR");

            migrationBuilder.DropTable(
                name: "PUBLISHER");
        }
    }
}
