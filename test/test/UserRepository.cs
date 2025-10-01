using System;
using System.Configuration;
using System.Data.SqlClient;

namespace test
{
    public class UserRepository
    {
        private readonly string _connectionString;
        public UserRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["UserAuthDB"].ConnectionString;
        }

        public bool UsernameExists(string username)
        {
            const string sql = "SELECT COUNT(1) FROM Users WHERE Username = @Username";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool EmailExists(string email)
        {
            const string sql = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void CreateUser(string username, string email, string phone, string passwordHash)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Users (Username, Email, Phone, PasswordHash, IsEmailConfirmed, CreatedAt)
                       VALUES (@Username, @Email, @Phone, @PasswordHash, 1, GETDATE())";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", (object)phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public User GetUserByLogin(string userOrEmailOrPhone)
        {
            const string sql = @"SELECT UserId, Username, Email, Phone, PasswordHash, IsEmailConfirmed FROM Users 
                                 WHERE Username = @q OR Email = @q OR Phone = @q";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@q", userOrEmailOrPhone);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserId = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.IsDBNull(3) ? null : reader.GetString(3),
                            PasswordHash = reader.GetString(4),
                            IsEmailConfirmed = reader.GetBoolean(5)
                        };
                    }
                }
            }
            return null;
        }

        public bool TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
