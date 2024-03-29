﻿using GroupTogether.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroupTogether.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
    }
}
