using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public int time;
        public double distance;
        public readonly int MINIMUM_FARE;
        public readonly int COST_PER_KM;
        public readonly int COST_PER_MINUTE;
        public RideType rideType;

        public Ride(double distance, int time, RideType rideType)
        {
            this.distance = distance;
            this.time = time;
            this.rideType = rideType;

            if (rideType == RideType.NORMAL)
            {
                MINIMUM_FARE = 5;
                COST_PER_KM = 10;
                COST_PER_MINUTE = 1;
            }
            else
            {
                MINIMUM_FARE = 20;
                COST_PER_KM = 15;
                COST_PER_MINUTE = 2;
            }
        }
    }
}

