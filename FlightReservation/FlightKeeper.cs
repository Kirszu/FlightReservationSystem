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

        internal void Delete(string flightId)
        {
            foreach (var flight in flightList)
            {
                if (string.Equals(flight.flightId, flightId))
                {
                    flightList.Remove(flight);
                    break;
                }
            }
        }
        public override string ToString()
        {
            string result = "";
            foreach (var flight in flightList)
            {
                result+= flight.flightId + "\n";
            }
            return result;
        }
    }
}