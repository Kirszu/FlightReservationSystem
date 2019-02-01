using System;
using System.Collections.Generic;

namespace FlightReservation
{
    public class Flight
    {
        private DateTime departure;
        private DateTime arrival;
        private float distance;
        private string from;
        private string destination;
        public string flightId;
        public IPlane plane;
        public List<string> bookedSeats = new List<string>();

        public Flight(string from, string destination, DateTime departure, DateTime arrival, float distance, IPlane plane)
        {
            this.departure = departure;
            this.arrival = arrival;
            this.distance = distance;
            this.from = from;
            this.destination = destination;
            this.plane = plane;
            this.flightId = $"{from}:{destination}-{departure.ToString("ddMMyyyyHHmmss")}";
        }
    }
}