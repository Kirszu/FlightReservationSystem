using System.Collections.Generic;
namespace FlightReservation
{
    public class Customer
    {
        public string Name;
        public Dictionary<Flight, List<string>> BookedFlights = new Dictionary<Flight, List<string>>();

        public Customer(string name)
        {
            this.Name = name;
        }

        public void BookFlight(Flight flight, string seat)
        {
            if (BookedFlights.ContainsKey(flight))
            {
                BookedFlights[flight].Add(seat);
            } 
            else
            {
                BookedFlights.Add(flight, new List<string>());
                BookedFlights[flight].Add(seat);
            }
                
            flight.bookedSeats.Add(seat);
        }
    }
}