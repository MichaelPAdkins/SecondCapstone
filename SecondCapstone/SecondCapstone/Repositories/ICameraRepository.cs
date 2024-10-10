using SecondCapstone.Models;
using System.Collections.Generic;

namespace SecondCapstone.Repositories
{
    public interface ICameraRepository
    {
        List<Camera> GetAll();
        Camera GetById(int id);
        void Add(Camera camera);
        void Update(Camera camera);
        void Delete(int id);
    }
}
