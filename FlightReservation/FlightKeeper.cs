using System;
using System.Collections.Generic;

namespace FlightReservation
{
    public class FlightKeeper
    {
        public FlightKeeper()
        {
        }

        public List<Flight> flightList = new List<Flight>();

        internal void Add(Flight flight)
        {
            flightList.Add(flight);
        }
    }
}