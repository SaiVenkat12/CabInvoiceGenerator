using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(5, 8, 58, RideType.NORMAL)]
        [DataRow(5, 10, 95, RideType.PREMIUM)]
        public void Given_Distance_And_Time_Return_TotalFare(double distance, int time, double expected, RideType rideType)
        {
            //Arrange
            InvoiceGenerator invoice = new InvoiceGenerator();
            Ride ride = new Ride(distance, time, rideType);
            //Act
            double actual = invoice.CalculateFare(ride);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void Given_Distance_And_Time_Return_TotalFare_MultipleRides()
        {
            //Arrange
            InvoiceGenerator invoice = new InvoiceGenerator();
            Ride[] rides = new Ride[]
            {
                new Ride(5, 8, RideType.NORMAL),
                new Ride(5, 10, RideType.PREMIUM),
            };
            //Act
            double actual = invoice.CalculateFare(rides);
            //Assert
            Assert.AreEqual(actual, 153);
        }

    }
}