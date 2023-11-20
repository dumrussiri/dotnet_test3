using dotnet_3.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_3.Data;
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories {  get; set; }
    }