using SecondCapstone.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SecondCapstone.Repositories
{
    public class CameraRepository : ICameraRepository
    {
        private readonly string _connectionString;
        public CameraRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Camera> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Camera;";
                    var reader = cmd.ExecuteReader();
                    var cameras = new List<Camera>();
                    while (reader.Read())
                    {
                        var camera = new Camera()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                        cameras.Add(camera);
                    }
                    reader.Close();
                    return cameras;
                }
            }
        }

        public Camera GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Camera WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var camera = new Camera()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                        reader.Close();
                        return camera;
                    }
                    reader.Close();
                    return null;
                }
            }
        }

        public void Add(Camera camera)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Camera (Name)
                        OUTPUT INSERTED.ID
                        VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", camera.Name);

                    camera.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Camera camera)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Camera 
                        SET Name = @name
                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", camera.Id);
                    cmd.Parameters.AddWithValue("@name", camera.Name);

                    cmd.ExecuteNonQuery();
                }
            }
        }

public List<Camera> GetBySearchQuery(string query)
{
    using (var conn = Connection)
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = @"
                SELECT Id, Name 
                FROM Camera 
                WHERE Name LIKE @query";
            cmd.Parameters.AddWithValue("@query", $"%{query}%");

            var reader = cmd.ExecuteReader();
            var cameras = new List<Camera>();
            while (reader.Read())
            {
                cameras.Add(new Camera()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                });
            }
            reader.Close();
            return cameras;
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
                    cmd.CommandText = "DELETE FROM Camera WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
