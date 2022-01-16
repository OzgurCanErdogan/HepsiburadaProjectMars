using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HepsiburadaProjectMars.Test
{
    [TestClass]
    public class GroundControlTest
    {
        [TestMethod]
        public void GroundControlRegexTest()
        {
            GroundControl groundControl = new GroundControl();
            groundControl.SetOrder("5 5");
            groundControl.SetOrder("1 2 N");
            groundControl.SetOrder("MMRMMRMRRM");
            MarsOrders orders = groundControl.SendOrder();
            Assert.IsNotNull(groundControl);
            Assert.IsNotNull(orders);
            Assert.AreEqual(5, orders.ZoneBorder.X);
            Assert.AreEqual(5, orders.ZoneBorder.Y);
            Assert.AreEqual(1, orders.Rovers[0].Position.X);
            Assert.AreEqual(2, orders.Rovers[0].Position.Y);
            Assert.AreEqual("MMRMMRMRRM", orders.RoverOrders[0]);
        }

    }
}
