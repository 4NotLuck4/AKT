using System.Configuration;
using System.Text.Json; // Newtonsoft.Json

Console.WriteLine("Hello, World!");

// json
string fileName = "users.json";
string json = File.ReadAllText(fileName);

// read - deserialize
JsonSerializerOptions options = new()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

var users = JsonSerializer.Deserialize<List<User>>(json);

// write - serialize
options = new()
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};
//json = JsonSerializer.Deserialize<List<User>>(users, options);


var login = ConfigurationManager.AppSettings["login"];

login = "менеджер";
var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
config.AppSettings.Settings["Login"].Value = "менеджер";
config.Save();
ConfigurationManager.RefreshSection("AppSettings");

login = ConfigurationManager.AppSettings["login"];




Console.WriteLine();