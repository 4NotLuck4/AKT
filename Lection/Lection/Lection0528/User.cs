
//// txt
//string fileName = "setting.txt";
//var data = File.ReadAllText("");

//// csv
//fileName = "settings.csv";
//var csv = File.ReadAllLines(fileName);
//foreach (var line in csv)
//{
//    var cells = line.Split(';');
//    var login = cells[0];
//    var password = cells[1];
//    var age = Int32.Parse(cells[2]);
//}

// xml

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}