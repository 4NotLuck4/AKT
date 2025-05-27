using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractWord4
{
    public class GameViewModel
    {
        public List<Game> Games { get; set; }
        public GameViewModel()
        {
            Games = new List<Game>
            {
                  new Game{IdGame = 1, Name = "Tetris", Category = "головоломка", Price = 150},
                  new Game{IdGame = 2, Name = "Flappy Bird", Description = "игра про летучую птицу", Category = "платформер", Price = 10},
                  new Game{IdGame = 3, Name = "Pac-man", Description = "игра про колобка", Category = "аркада", Price = 300},
                  new Game{IdGame = 4, Name = "Arkanoid", Category = "аркада", Price = 400},
                  new Game{IdGame = 5, Name = "Mario", Description = "игра про Марио", Category = "платформер", Price = 1000},
                  new Game{IdGame = 6, Name = "Tetris2", Price = 150},
                  new Game{IdGame = 7, Name = "Flappy Bird2", Description = "игра про летучую птицу", Category = "платформер", Price = 10},
                  new Game{IdGame = 8, Name = "Pac-man2", Description = "игра про колобка", Price = 300},
                  new Game{IdGame = 9, Name = "Arkanoid2", Category = "аркада", Price = 400},
                  new Game{IdGame = 10, Name = "Mario2", Description = "игра про Марио", Price = 1000},
            };
        }
    }
}
