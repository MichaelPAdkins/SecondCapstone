using SecondCapstone.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SecondCapstone.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly string _connectionString;
        public LocationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Location> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Locations;";
                    var reader = cmd.ExecuteReader();
                    var locations = new List<Location>();
                    while (reader.Read())
                    {
                        var location = new Location()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                        locations.Add(location);
                    }
                    reader.Close();
                    return locations;
                }
            }
        }

        public Location GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Locations WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var location = new Location()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                        reader.Close();
                        return location;
                    }
                    reader.Close();
                    return null;
                }
            }
        }

        public void Add(Location location)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Locations (Name)
                        OUTPUT INSERTED.ID
                        VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", location.Name);

                    location.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

public List<Location> GetBySearchQuery(string query)
{
    using (var conn = Connection)
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = @"
                SELECT Id, Name 
                FROM Locations 
                WHERE Name LIKE @query";
            cmd.Parameters.AddWithValue("@query", $"%{query}%");

            var reader = cmd.ExecuteReader();
            var locations = new List<Location>();
            while (reader.Read())
            {
                locations.Add(new Location()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                });
            }
            reader.Close();
            return locations;
        }
    }
}


        
        public void Update(Location location)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Locations 
                        SET Name = @name
                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", location.Id);
                    cmd.Parameters.AddWithValue("@name", location.Name);

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
                    cmd.CommandText = "DELETE FROM Locations WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
