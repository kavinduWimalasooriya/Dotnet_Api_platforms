using Microsoft.EntityFrameworkCore;
using PlateformService.Models;

namespace PlateformService.DataAccess
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) :base(option)
        {
            
        }
        public DbSet<Platform> Platforms { get; set; }
        
        
    }
    
}