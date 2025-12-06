using Microsoft.EntityFrameworkCore;
using CafeInventoryApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace CafeInventoryApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Item> Items {get; set;}
    }
}