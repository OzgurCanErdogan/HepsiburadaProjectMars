using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaProjectMars
{
    public class MarsOrders : Object
    {
        public CardinalSystem ZoneBorder { get; set; }
        public List<RoverPositionMessage> Rovers { get; set; }
        public List<string> RoverOrders { get; set; }
        
    }
}
