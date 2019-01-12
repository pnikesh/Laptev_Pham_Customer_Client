using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laptev_Pham_Customer_Client.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string FlightName { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public bool Direct { get; set; }
        public int TicketPrice { get; set; }

    }
}