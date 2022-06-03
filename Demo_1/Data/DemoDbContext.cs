using System;
using Demo_1.Entities;
using Microsoft.EntityFrameworkCore;


namespace Demo_1.Data
{
    public class DemoDbContext : DbContext
    {
        public DbSet<CoronaModel> CoronaModels { get; set; }

        public string DbPath { get; }

        public DemoDbContext()
        {
            DbPath = Path.Join(Environment.CurrentDirectory, "demo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}

