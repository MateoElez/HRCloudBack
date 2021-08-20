using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Models.BaseFolder;
using ProjectAPI.Models.CartFolder;
using ProjectAPI.Models;

namespace ProjectAPI.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<ProjectAPI.Models.CartItem> CartItem { get; set; }

    }
}
