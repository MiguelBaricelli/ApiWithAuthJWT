using ApiWithTokenJWT.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiWithTokenJWT.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

   public DbSet<User> Users { get; set; }
}