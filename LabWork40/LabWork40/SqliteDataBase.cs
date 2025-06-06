using Microsoft.Data.Sqlite;

namespace LabWork40;

internal class SqliteDataBase
{
    public async static void CreateDataBase(string dataBase)
    {
        string scriptCreateTabelGame = @"CREATE TABLE Game (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT NOT NULL, Description TEXT NOT NULL, PublicationYear INTEGER NOT NULL, Price REAL NOT NULL);";
        string scriptCreateTabelReview = @"CREATE TABLE Review (Id INTEGER PRIMARY KEY AUTOINCREMENT, GameId INTEGER NOT NULL, User TEXT NOT NULL, Comment TEXT NOT NULL, PublicationDate TEXT NOT NULL, FOREIGN KEY (GameId) REFERENCES Game(Id));";

        using (SqliteConnection connection = new($"Data Source={dataBase}"))
        {
            await connection.OpenAsync();

            SqliteCommand commandCreateTableGame = new(scriptCreateTabelGame, connection);
            await commandCreateTableGame.ExecuteNonQueryAsync();
        }
        
    }
}
