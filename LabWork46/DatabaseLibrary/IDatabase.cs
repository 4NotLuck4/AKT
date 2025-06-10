using System;
namespace DatabaseLibrary
{
    public interface IDatabase
    {
        int ExecutrQuery(string sql);
        bool UpdateGame(int id, string newName, decimal newPrice);
        void InsertGame(string name, decimal price, int releaseYear);
    }
}