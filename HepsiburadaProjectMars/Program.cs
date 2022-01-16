using System;
using System.Collections.Generic;

namespace HepsiburadaProjectMars
{
    class Program
    {
        static void Main(string[] args)
        {
            GroundControl groundControl = new GroundControl();
            groundControl.ReadOrder();
            MarsOrders orders = groundControl.SendOrder();
            SurfaceArea surfaceArea = new SurfaceArea(new CardinalSystem(0, 0), orders.ZoneBorder);
            List<MarsRover> rovers = new List<MarsRover>();
            
            for (int i = 0; i < orders.Rovers.Count; i++)
            {
                if (i >= orders.RoverOrders.Count)
                    orders.RoverOrders.Add("");

                string order = orders.RoverOrders[i] == null ? "": orders.RoverOrders[i];
                rovers.Add(new MarsRover(orders.Rovers[i], String.IsNullOrWhiteSpace(order) ? "": order, surfaceArea));
            }

            for(int i = 0; i<rovers.Count; i++)
            {
                rovers[i].ExecuteOrder();
                Console.WriteLine("Rover-"+ (i+1) + ": " + rovers[i].GetRoverPosition().ToString() + " " + rovers[i].GetRoverDirection());
            }

            Console.ReadKey();
        }
    }
}
