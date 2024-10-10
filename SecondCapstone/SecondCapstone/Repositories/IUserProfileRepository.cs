using SecondCapstone.Models;
using System.Collections.Generic;

namespace SecondCapstone.Repositories
{
    public interface IUserProfileRepository
    {
        List<UserProfile> GetAll();
        UserProfile GetById(int id);
        void Add(UserProfile userProfile);
        void Update(UserProfile userProfile);
        void Delete(int id);
    }
}
