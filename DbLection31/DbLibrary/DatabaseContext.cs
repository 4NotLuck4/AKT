using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DbLibrary
{
    public class DatabaseContext
    {
        public static string ConnectionString { get; set; } = "Data Source=mssql;Initial Catalog=ispp3102;Persist Security Info=True;User ID=ispp3102;Password=3102;Encrypt=True;Trust Server Certificate=True";
        public void ExecuteCommand(string query)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();
            SqlCommand command = new(query, connection);
            command.ExecuteNonQuery();
        }

        public static Review? GetReviews(Review id)
        {
            IDbConnection db = new SqlConnection(ConnectionString);
            return db.QueryFirstOrDefault<Review>("SELECT * FROM Review WHERE ID=@id", new { id });
        }
        public static Review? UpdateReviews(Review review)
        {
            IDbConnection db = new SqlConnection(ConnectionString);
            return db.Execute("UPDATE Review SET FROM Review WHERE ID=@id", new { review });
        }
    }
}
