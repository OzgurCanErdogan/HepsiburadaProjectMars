using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HepsiburadaProjectMars
{
    public class GroundControl : IStation<MarsOrders>
    {
        private MarsOrders MarsMissionDetails { get; set; }
        public MarsOrders SendOrder()
        {
            return MarsMissionDetails;
        }
        public GroundControl()
        {
            MarsMissionDetails = new MarsOrders();
            MarsMissionDetails.Rovers = new List<RoverPositionMessage>();
            MarsMissionDetails.RoverOrders = new List<string>();
            
        }
        public void SetOrder(string line)
        {
            Regex regexForArea = new Regex(@"^([0-9]+)[\s]([0-9]+)$"); //Regex for Mars Surface Area
            Regex regexForPosition = new Regex(@"^([0-9]+)[\s]([0-9]+)[\s]([NWSE])$"); //Regex for Mars Rover's initial point
            Regex regexForMoveOrder = new Regex(@"^[LRM]*$"); //Regex for Mars Rover's execution order
            Match temp;
            if (regexForArea.IsMatch(line))
            {
                temp = regexForArea.Match(line);
                MarsMissionDetails.ZoneBorder = new CardinalSystem(Int32.Parse(temp.Groups[1].Value), Int32.Parse(temp.Groups[2].Value));
            }
            else if (regexForPosition.IsMatch(line))
            {
                temp = regexForPosition.Match(line);
                
                MarsMissionDetails.Rovers.Add(new RoverPositionMessage(new CardinalSystem(Int32.Parse(temp.Groups[1].Value), Int32.Parse(temp.Groups[2].Value)), SetDirection(temp.Groups[3].Value[0])));
            }
            else if (regexForMoveOrder.IsMatch(line))
            {
                MarsMissionDetails.RoverOrders.Add(line);
            }
            else
            {
                throw new Exception("There is a problem in order file."); //throws when there is a problem in input text format.
            }
        }
        
        public void ReadOrder() //Reads input from a file
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Orders.txt");
            string[] files = File.ReadAllLines(path);
            foreach(var item in files)
            {
                SetOrder(item);
            }
        }
        internal GeographicDirection SetDirection(char positionInfo)
        {
            if (positionInfo == 'N')
            {
                return GeographicDirection.N;
            }
            else if (positionInfo == 'E')
            {
                return GeographicDirection.E;
            }
            else if (positionInfo == 'S')
            {
                return GeographicDirection.S;
            }
            else
            {
                return GeographicDirection.W;
            }
        }
    }
}
