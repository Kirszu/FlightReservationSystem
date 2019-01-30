using System.Collections.Generic;
namespace FlightReservation
{
    public class Customer
    {
        public string Name;
        public List<Flight> BookedFlights = new List<Flight>();

        public Customer(string name)
        {
            this.Name = name;
        }

        public void BookFlight(Flight flight)
        {
            BookedFlights.Add(flight);
        }
    }
}