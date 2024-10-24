using SecondCapstone.Models;
using Microsoft.Data.SqlClient;
using SecondCapstone.Extensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SecondCapstone.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly string? _connectionString;
        public EntryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        // Helper Method to Build Entry Object from SQL Reader
private Entry BuildEntryFromReader(SqlDataReader reader)
{
    var entry = new Entry()
    {
        Id = reader.GetInt32(reader.GetOrdinal("Id")),
        FileName = reader.IsDBNull(reader.GetOrdinal("FileName")) ? null : reader.GetString(reader.GetOrdinal("FileName")),
        CaptureDate = reader.IsDBNull(reader.GetOrdinal("CaptureDate")) ? null : reader.GetString(reader.GetOrdinal("CaptureDate")),
        FileSize = reader.IsDBNull(reader.GetOrdinal("FileSize")) ? null : reader.GetString(reader.GetOrdinal("FileSize")),
        Resolution = reader.IsDBNull(reader.GetOrdinal("Resolution")) ? null : reader.GetString(reader.GetOrdinal("Resolution")),
        PhysicalBackUps = reader.IsDBNull(reader.GetOrdinal("PhysicalBackUps")) ? null : reader.GetString(reader.GetOrdinal("PhysicalBackUps")),
        Camera = new Camera()
        {
            Name = reader.IsDBNull(reader.GetOrdinal("CameraName")) ? null : reader.GetString(reader.GetOrdinal("CameraName"))
        },
        EntryLocations = new List<Location>(),
        EntryTags = new List<Tag>()
    };

    // Safely check for LocationName column
    if (reader.HasColumn("LocationName") && !reader.IsDBNull(reader.GetOrdinal("LocationName")))
    {
        entry.EntryLocations.Add(new Location
        {
            Name = reader.GetString(reader.GetOrdinal("LocationName"))
        });
    }

    // Safely check for TagName column
    if (reader.HasColumn("TagName") && !reader.IsDBNull(reader.GetOrdinal("TagName")))
    {
        entry.EntryTags.Add(new Tag
        {
            Name = reader.GetString(reader.GetOrdinal("TagName"))
        });
    }

    return entry;
}



        // Get all entries with related data
        public List<Entry> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT e.Id, e.FileName, e.CaptureDate, e.FileSize, e.Resolution, e.PhysicalBackUps,
                               c.Name as CameraName, l.Name as LocationName, t.Name as TagName
                        FROM Entry e
                        LEFT JOIN Camera c ON e.CameraId = c.Id
                        LEFT JOIN EntryLocations el ON el.EntryId = e.Id
                        LEFT JOIN Locations l ON el.LocationsId = l.Id
                        LEFT JOIN EntryTags et ON et.EntryId = e.Id
                        LEFT JOIN Tags t ON et.TagId = t.Id
                        ORDER BY e.Id DESC;";

                    var reader = cmd.ExecuteReader();
                    var entries = new List<Entry>();

                    while (reader.Read())
                    {
                        entries.Add(BuildEntryFromReader(reader));
                    }
                    reader.Close();
                    return entries;
                }
            }
        }

        // Get entry by Id
        public Entry GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT e.Id, e.FileName, e.CaptureDate, e.FileSize, e.Resolution, e.PhysicalBackUps,
                               c.Name as CameraName, l.Name as LocationName, t.Name as TagName
                        FROM Entry e
                        LEFT JOIN Camera c ON e.CameraId = c.Id
                        LEFT JOIN EntryLocations el ON el.EntryId = e.Id
                        LEFT JOIN Locations l ON el.LocationsId = l.Id
                        LEFT JOIN EntryTags et ON et.EntryId = e.Id
                        LEFT JOIN Tags t ON et.TagId = t.Id
                        WHERE e.Id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var entry = BuildEntryFromReader(reader);
                        reader.Close();
                        return entry;
                    }
                    reader.Close();
                    return null;
                }
            }
        }

        // Add entry
        public void Add(Entry entry)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Entry (FileName, CaptureDate, FileSize, Resolution, PhysicalBackUps, CameraId, UserId)
                        OUTPUT INSERTED.ID
                        VALUES (@fileName, @captureDate, @fileSize, @resolution, @physicalBackUps, @cameraId, @userId)";

                    cmd.Parameters.AddWithValue("@fileName", entry.FileName);
                    cmd.Parameters.AddWithValue("@captureDate", entry.CaptureDate);
                    cmd.Parameters.AddWithValue("@fileSize", entry.FileSize);
                    cmd.Parameters.AddWithValue("@resolution", entry.Resolution);
                    cmd.Parameters.AddWithValue("@physicalBackUps", entry.PhysicalBackUps);
                    cmd.Parameters.AddWithValue("@cameraId", entry.CameraId);
                    cmd.Parameters.AddWithValue("@userId", entry.UserId);

                    entry.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        // Update entry
        public void Update(Entry entry)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Entry 
                        SET FileName = @fileName, CaptureDate = @captureDate, FileSize = @fileSize, 
                            Resolution = @resolution, PhysicalBackUps = @physicalBackUps, 
                            CameraId = @cameraId, UserId = @userId
                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", entry.Id);
                    cmd.Parameters.AddWithValue("@fileName", entry.FileName);
                    cmd.Parameters.AddWithValue("@captureDate", entry.CaptureDate);
                    cmd.Parameters.AddWithValue("@fileSize", entry.FileSize);
                    cmd.Parameters.AddWithValue("@resolution", entry.Resolution);
                    cmd.Parameters.AddWithValue("@physicalBackUps", entry.PhysicalBackUps);
                    cmd.Parameters.AddWithValue("@cameraId", entry.CameraId);
                    cmd.Parameters.AddWithValue("@userId", entry.UserId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete entry
        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Entry WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Get last 10 entries with related data
        public List<Entry> GetLastTenEntries()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT TOP 10 e.Id, e.FileName, e.CaptureDate, e.FileSize, e.Resolution, e.PhysicalBackUps,
                               c.Name as CameraName, l.Name as LocationName, t.Name as TagName
                        FROM Entry e
                        LEFT JOIN Camera c ON e.CameraId = c.Id
                        LEFT JOIN EntryLocations el ON el.EntryId = e.Id
                        LEFT JOIN Locations l ON el.LocationsId = l.Id
                        LEFT JOIN EntryTags et ON et.EntryId = e.Id
                        LEFT JOIN Tags t ON et.TagId = t.Id
                        ORDER BY e.CaptureDate DESC;";

                    var reader = cmd.ExecuteReader();
                    var entries = new List<Entry>();

                    while (reader.Read())
                    {
                        entries.Add(BuildEntryFromReader(reader));
                    }
                    reader.Close();
                    return entries;
                }
            }
        }

        // Get entries by TagId
        public List<Entry> GetEntriesByTagId(int tagId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT e.Id, e.FileName, e.CaptureDate, e.FileSize, e.Resolution, e.PhysicalBackUps, 
                               c.Name as CameraName, t.Name as TagName
                        FROM Entry e
                        JOIN EntryTags et ON et.EntryId = e.Id
                        LEFT JOIN Camera c ON e.CameraId = c.Id
                        LEFT JOIN Tags t ON et.TagId = t.Id
                        WHERE et.TagId = @tagId;";

                    cmd.Parameters.AddWithValue("@tagId", tagId);
                    var reader = cmd.ExecuteReader();
                    var entries = new List<Entry>();

                    while (reader.Read())
                    {
                        entries.Add(BuildEntryFromReader(reader));
                    }
                    reader.Close();
                    return entries;
                }
            }
        }

        // Get entries by LocationId
        public List<Entry> GetEntriesByLocationId(int locationId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT e.Id, e.FileName, e.CaptureDate, e.FileSize, e.Resolution, e.PhysicalBackUps, 
                               c.Name as CameraName, l.Name as LocationName
                        FROM Entry e
                        JOIN EntryLocations el ON el.EntryId = e.Id
                        LEFT JOIN Camera c ON e.CameraId = c.Id
                        LEFT JOIN Locations l ON el.LocationsId = l.Id
                        WHERE el.LocationsId = @locationId;";

                    cmd.Parameters.AddWithValue("@locationId", locationId);
                    var reader = cmd.ExecuteReader();
                    var entries = new List<Entry>();

                    while (reader.Read())
                    {
                        entries.Add(BuildEntryFromReader(reader));
                    }
                    reader.Close();
                    return entries;
                }
            }
        }

        // Get entries by CameraId
        public List<Entry> GetEntriesByCameraId(int cameraId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT e.Id, e.FileName, e.CaptureDate, e.FileSize, e.Resolution, e.PhysicalBackUps, 
                               c.Name as CameraName
                        FROM Entry e
                        LEFT JOIN Camera c ON e.CameraId = c.Id
                        WHERE e.CameraId = @cameraId;";

                    cmd.Parameters.AddWithValue("@cameraId", cameraId);
                    var reader = cmd.ExecuteReader();
                    var entries = new List<Entry>();

                    while (reader.Read())
                    {
                        entries.Add(BuildEntryFromReader(reader));
                    }
                    reader.Close();
                    return entries;
                }
            }
        }
    }
}
