using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Management> Managements { get; set; }

       
    }
}
