using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Clicker
{
    public class GameLogic
    {
        public GameState State { get; } = new GameState();
        public int GrandmaPrice => 15;

        public void ClickCookie()
        {
            State.Cookies++;
        }

        public void BuyGrandma()
        {
            if (!CanBuyGrandma()) return;

            State.Cookies -= GrandmaPrice;
            State.Grandmas++;
        }

        public bool CanBuyGrandma()
        {
            return State.Cookies >= GrandmaPrice;
        }

        public void Tick()
        {
            State.Cookies += State.Grandmas;
        }
    }
}
