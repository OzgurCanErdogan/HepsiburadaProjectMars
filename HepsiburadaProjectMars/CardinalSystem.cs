using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaProjectMars
{
    public enum GeographicDirection
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }
    public class CardinalSystem
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CardinalSystem(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return X + " " + Y;
        }
    }
}
