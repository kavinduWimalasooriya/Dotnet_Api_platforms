using System.Collections.Generic;
using PlateformService.Models;

namespace PlateformService.DataAccess
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
        
    }
}