using BasicUnitTest.Core;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BasicUnitTest.Migrations
{
    public partial class SeedVideoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql("Insert INTO Videos (Title, IsProcessed) Values ('Video 3', 0);");
            migrationBuilder.Sql("Insert INTO Videos (Title, IsProcessed) Values ('Video 4', 1);");
            migrationBuilder.Sql("Insert INTO Videos (Title, IsProcessed) Values ('Video 5', 0);");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete Videos Where Title In ('Video 3', 'Video 4', 'Video 5');");
        }
    }
}
