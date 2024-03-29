﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
namespace WebShop.Data
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Spaceship> Spaceship { get; set; }

        public DbSet<House> House { get; set; }
        public DbSet<ExistingFilePath> ExistingFilePath { get; set; }
    }
}
