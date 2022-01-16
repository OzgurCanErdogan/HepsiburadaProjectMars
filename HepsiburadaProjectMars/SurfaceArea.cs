using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaProjectMars
{
    public class SurfaceArea
    {
        public CardinalSystem StartPoint { get; set; }
        public CardinalSystem LimitPoint { get; set; }
        public SurfaceArea(CardinalSystem startPoint, CardinalSystem limitPoint)
        {
            StartPoint = startPoint;
            LimitPoint = limitPoint;
        }

    }
}
