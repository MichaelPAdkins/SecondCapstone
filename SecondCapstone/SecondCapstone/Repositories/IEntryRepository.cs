using SecondCapstone.Models;
using System.Collections.Generic;

namespace SecondCapstone.Repositories
{
    public interface IEntryRepository
    {
        List<Entry> GetAll();
        Entry GetById(int id);
        void Add(Entry entry);
        void Update(Entry entry);
        void Delete(int id);
        List<Entry> GetLastTenEntries(); 
    }
}
