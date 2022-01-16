using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HepsiburadaProjectMars.Test
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void MarsRoverTestInput()
        {
            SurfaceArea surfaceArea = new SurfaceArea(new CardinalSystem(0,0), new CardinalSystem(5, 5));
            MarsRover rover1 = new MarsRover(new CardinalSystem(1, 2), GeographicDirection.N, surfaceArea);
            rover1.ReadOrder("LMLMLMLMM");
            rover1.ExecuteOrder();

            MarsRover rover2 = new MarsRover(new CardinalSystem(3, 3), GeographicDirection.E, surfaceArea);
            rover2.ReadOrder("MMRMMRMRRM");
            rover2.ExecuteOrder();

            Assert.IsNotNull(rover1);
            Assert.AreEqual(GeographicDirection.N, rover1.GetRoverDirection());
            Assert.AreEqual(1, rover1.GetRoverPosition().X);
            Assert.AreEqual(3, rover1.GetRoverPosition().Y);

            Assert.IsNotNull(rover2);
            Assert.AreEqual(GeographicDirection.E, rover2.GetRoverDirection());
            Assert.AreEqual(5, rover2.GetRoverPosition().X);
            Assert.AreEqual(1, rover2.GetRoverPosition().Y);
        }

        
    }
}
