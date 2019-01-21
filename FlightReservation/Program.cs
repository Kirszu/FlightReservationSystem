using System;

namespace FlightReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightKeeper fk = new FlightKeeper();
            DateTime departure = new DateTime(2019, 6, 1, 7, 47, 0);
            DateTime arrival = new DateTime(2019, 6, 1, 12, 4, 0);
            Boeing plane = new Boeing();
            Flight flight = new Flight("WAW", "LIS", departure, arrival, 902.2f, plane);
            fk.Add(flight);
            departure = new DateTime(2019, 7, 1, 12, 42, 22);
            arrival = new DateTime(2019, 7, 1, 15, 14, 21);
            plane = new Boeing();
            flight = new Flight("WAW", "LON", departure, arrival, 732.5f, plane);
            fk.Add(flight);
            departure = new DateTime(2019, 7, 1, 08, 22, 22);
            arrival = new DateTime(2019, 7, 1, 09, 15, 13);
            Airbus plane2 = new Airbus();
            flight = new Flight("WAW", "GDA", departure, arrival, 412.5f, plane2);
            fk.Add(flight);
            Console.WriteLine(fk.ToString());
            fk.Delete("WAW:GDA-01072019082222");
            Console.WriteLine(fk.ToString());
            Console.ReadLine();
        }
    }
}
