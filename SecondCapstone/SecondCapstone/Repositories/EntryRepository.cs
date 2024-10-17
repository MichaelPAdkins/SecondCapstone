using SecondCapstone.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SecondCapstone.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly string _connectionString;
        public EntryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Entry> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Entry;";
                    var reader = cmd.ExecuteReader();
                    var entries = new List<Entry>();
                    while (reader.Read())
                    {
                        var entry = new Entry()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FileName = reader.GetString(reader.GetOrdinal("FileName")),
                            CaptureDate = reader.GetString(reader.GetOrdinal("CaptureDate")),
                            FileSize = reader.GetString(reader.GetOrdinal("FileSize")),
                            Resolution = reader.GetString(reader.GetOrdinal("Resolution")),
                            PhysicalBackUps = reader.GetString(reader.GetOrdinal("PhysicalBackUps")),
                            CameraId = reader.GetInt32(reader.GetOrdinal("CameraId")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };
                        entries.Add(entry);
                    }
                    reader.Close();
                    return entries;
                }
            }
        }

        public Entry GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Entry WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var entry = new Entry()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FileName = reader.GetString(reader.GetOrdinal("FileName")),
                            CaptureDate = reader.GetString(reader.GetOrdinal("CaptureDate")),
                            FileSize = reader.GetString(reader.GetOrdinal("FileSize")),
                            Resolution = reader.GetString(reader.GetOrdinal("Resolution")),
                            PhysicalBackUps = reader.GetString(reader.GetOrdinal("PhysicalBackUps")),
                            CameraId = reader.GetInt32(reader.GetOrdinal("CameraId")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };
                        reader.Close();
                        return entry;
                    }
                    reader.Close();
                    return null;
                }
            }
        }

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

        // Corrected GetLastTenEntries method
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
                        ORDER BY e.CaptureDate DESC";
                    
                    var reader = cmd.ExecuteReader();
                    var entries = new List<Entry>();
                    while (reader.Read())
                    {
                        var entry = new Entry()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FileName = reader.GetString(reader.GetOrdinal("FileName")),
                            CaptureDate = reader.GetString(reader.GetOrdinal("CaptureDate")),
                            FileSize = reader.GetString(reader.GetOrdinal("FileSize")),
                            Resolution = reader.GetString(reader.GetOrdinal("Resolution")),
                            PhysicalBackUps = reader.GetString(reader.GetOrdinal("PhysicalBackUps")),
                            Camera = new Camera()
                            {
                                Name = reader.IsDBNull(reader.GetOrdinal("CameraName")) ? null : reader.GetString(reader.GetOrdinal("CameraName"))
                            },
                            EntryLocations = new List<Location>(),
                            EntryTags = new List<Tag>()
                        };

                        // Add location if available
                        if (!reader.IsDBNull(reader.GetOrdinal("LocationName")))
                        {
                            entry.EntryLocations.Add(new Location
                            {
                                Name = reader.GetString(reader.GetOrdinal("LocationName"))
                            });
                        }

                        // Add tag if available
                        if (!reader.IsDBNull(reader.GetOrdinal("TagName")))
                        {
                            entry.EntryTags.Add(new Tag
                            {
                                Name = reader.GetString(reader.GetOrdinal("TagName"))
                            });
                        }

                        entries.Add(entry);
                    }
                    reader.Close();
                    return entries;
                }
            }
        }
    }
}
