using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagment.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookDatesToDateTimeOffsetToBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""BOOK"" 
                ALTER COLUMN ""PRINT_DATE"" 
                TYPE timestamp with time zone 
                USING CASE 
                    WHEN ""PRINT_DATE"" IS NULL OR ""PRINT_DATE"" = '' THEN NULL
                    ELSE ""PRINT_DATE""::timestamp with time zone 
                END;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""BOOK"" 
                ALTER COLUMN ""ACQUISITION_DATE"" 
                TYPE timestamp with time zone 
                USING CASE 
                    WHEN ""ACQUISITION_DATE"" IS NULL OR ""ACQUISITION_DATE"" = '' THEN NULL
                    ELSE ""ACQUISITION_DATE""::timestamp with time zone 
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""BOOK"" 
                ALTER COLUMN ""PRINT_DATE"" 
                TYPE character varying(50) 
                USING ""PRINT_DATE""::text;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""BOOK"" 
                ALTER COLUMN ""ACQUISITION_DATE"" 
                TYPE character varying(50) 
                USING ""ACQUISITION_DATE""::text;
            ");
        }
    }
}