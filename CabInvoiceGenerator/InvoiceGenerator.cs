using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private RideRepository rideRepo;
        public double CalculateFare(Ride ride)
        {
            double totalFare = 0;
            if (ride.distance <= 0)
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_DISTANCE, "distance should be above zero");
            else if (ride.time <= 0)
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_TIME, "time should be above zero");
            else
            {
                totalFare = ride.distance * ride.COST_PER_KM + ride.time * ride.COST_PER_MINUTE;
            }
            return Math.Max(totalFare, ride.MINIMUM_FARE);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
        public void AddRides(string userId, Ride[] rides)
        {
            rideRepo.AddRide(userId, rides);
        }
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            Console.WriteLine("\nGetting userId =>{0}", userId);
            return this.CalculateFare(rideRepo.GetRides(userId));
        }
    }
    
}
