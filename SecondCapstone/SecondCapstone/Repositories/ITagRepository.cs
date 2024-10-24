using SecondCapstone.Models;
using System.Collections.Generic;

namespace SecondCapstone.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetBySearchQuery(string query);
        List<Tag> GetAll();
        Tag GetById(int id);
        void Add(Tag tag);
        void Update(Tag tag);
        void Delete(int id);
    }
}
