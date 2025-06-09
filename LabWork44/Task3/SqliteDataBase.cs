using Microsoft.Data.Sqlite;

internal class SqliteDataBase
{
    public static void CreateDataBase(string dataBase)
    {
        string queryCreateTabelGame = @"CREATE TABLE Game (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Description TEXT NOT NULL,
                PublicationYear INTEGER NOT NULL,
                Price REAL NOT NULL
                );";
        string queryCreateTabelReview = @"CREATE TABLE Review (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                GameId INTEGER NOT NULL,
                User TEXT NOT NULL,
                Comment TEXT NOT NULL,
                PublicationDate TEXT NOT NULL,
                FOREIGN KEY (GameId) REFERENCES Game(Id)
                );";

        using (SqliteConnection connection = new($"Data Source={dataBase}"))
        {
            connection.Open();

            SqliteCommand command = new(queryCreateTabelGame, connection);
            command.ExecuteNonQuery();

            command = new(queryCreateTabelReview, connection);
            command.ExecuteNonQuery();
        }
    }
}