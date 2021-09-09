using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlateformService.Models;

namespace PlateformService.DataAccess
{
    public static class PrepDb
    {
        public static void PrePopulation(IApplicationBuilder app )
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                System.Console.WriteLine("Seeding Data ..........");
                context.Platforms.AddRange(
                    
                        new Platform { Id = 1,Name ="dotnet",Publisher ="Microsoft",Cost ="free"},
                        new Platform { Id = 2,Name ="Angular",Publisher ="Google",Cost ="free"},
                        new Platform { Id = 3,Name ="Django",Publisher ="django",Cost ="free"},
                        new Platform { Id = 4,Name ="Azure",Publisher ="Microsoft",Cost ="free"},
                        new Platform { Id = 5,Name ="react",Publisher ="facebook",Cost ="free"}
                    
                );
                context.SaveChanges();
                
            }
            else
            {
                System.Console.WriteLine("We allredy have data...........");
            }
        }
        
    }
}