using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int numbOfRides;
        public double totalFare;
        public double average;
        
        public InvoiceSummary(int numbOfRides, double totalFare)
        {
            this.totalFare = totalFare;
            this.numbOfRides = numbOfRides;
            this.average = totalFare / numbOfRides;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is InvoiceSummary))
            {
                return false;
            }
            InvoiceSummary inputedObj = (InvoiceSummary)obj;
            return numbOfRides == inputedObj.numbOfRides && totalFare == inputedObj.totalFare && average == inputedObj.average;
        }
    }
}
