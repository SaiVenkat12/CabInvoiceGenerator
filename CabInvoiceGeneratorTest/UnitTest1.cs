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
            InvoiceSummary actual = invoice.CalculateFare(rides);
            //Assert
            Assert.AreEqual(actual.totalFare, 153);
        }
        public void Given_MultipleRide_Should_TotalRides_TotalFare_And_AverageFare()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();
            Ride[] rides = new Ride[]
            {
                new Ride(5, 8, RideType.NORMAL),
                new Ride(5, 10, RideType.PREMIUM),
            };
            InvoiceSummary actual = invoice.CalculateFare(rides);
            Assert.AreEqual(actual.totalFare, 153);
            Assert.AreEqual(actual.average, 77.5);
            Assert.AreEqual(actual.numbOfRides, 2);
        }
        [TestMethod]
        public void Given_UserID_Should_Return_ListofRides_Invoice()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();
            Ride[] ride1 = new Ride[]
            {
                new Ride(5, 8, RideType.NORMAL),
                new Ride(5, 10, RideType.PREMIUM),
            };
            Ride[] ride2 = new Ride[]
            {
                new Ride(5, 8, RideType.NORMAL),
                new Ride(9, 8, RideType.NORMAL),
                new Ride(5, 10, RideType.PREMIUM),
            };
            invoice.AddRides("Abc", ride1);
            invoice.AddRides("Xyz", ride2);
            InvoiceSummary excepted1 = invoice.GetInvoiceSummary("Abc");
            InvoiceSummary excepted2 = invoice.GetInvoiceSummary("Xyz");
            //Assert.AreEqual(3, excepted2.numbOfRides);
            //Assert.AreEqual(153, excepted1.totalFare);
            Assert.AreEqual(77.5, excepted1.average);
        }
    }
}