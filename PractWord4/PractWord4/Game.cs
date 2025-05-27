namespace PractWord4
{
    // типы данных
    public class Game
    {
        public int IdGame { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public double Price { get; set; }
        public double Sale { get; set; } = 0;
    }

    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
