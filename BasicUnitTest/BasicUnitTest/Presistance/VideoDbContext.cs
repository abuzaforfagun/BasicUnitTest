using BasicUnitTest.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicUnitTest.Presistance
{
    class VideoDbContext:DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public VideoDbContext()
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=.\;Database=VideoDb;Trusted_Connection=True;");
        }
    }
}
