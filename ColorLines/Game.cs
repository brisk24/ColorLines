using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorLines
{
    internal class Game
    {
        int[,] map; // 0-пусто, 1-6 шарик цвета N
        int max;
        ShowItem show;
        public Game(int max, ShowItem show)
        {
            this.max = max;
            map = new int[max, max];
            this.show = show;
        }
    }
}
