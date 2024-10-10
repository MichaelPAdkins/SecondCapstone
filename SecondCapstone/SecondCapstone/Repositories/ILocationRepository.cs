using SecondCapstone.Models;
using System.Collections.Generic;

namespace SecondCapstone.Repositories
{
    public interface ILocationRepository
    {
        List<Location> GetAll();
        Location GetById(int id);
        void Add(Location location);
        void Update(Location location);
        void Delete(int id);
    }
}
