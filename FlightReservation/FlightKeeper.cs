using System;
using System.Collections.Generic;

namespace FlightReservation
{
    public static class FlightKeeper
    {

        public static List<Flight> flightList = new List<Flight>();

        internal static void Add(Flight flight)
        {
            flightList.Add(flight);
        }

        internal static void Delete(string flightId)
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
        public static new string ToString()
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