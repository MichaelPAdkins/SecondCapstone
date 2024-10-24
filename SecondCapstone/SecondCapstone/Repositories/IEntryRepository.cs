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
        List<Entry> GetEntriesByTagId(int tagId);
        List<Entry> GetEntriesByLocationId(int locationId);
        List<Entry> GetEntriesByCameraId(int cameraId);
        List<Entry> GetLastTenEntries();
    }
}
