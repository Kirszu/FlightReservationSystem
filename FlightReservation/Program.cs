using System;
using System.Collections.Generic;

namespace FlightReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerList customerList = new CustomerList();
            Console.WriteLine("Add new customer");
            Customer customer = new Customer(Console.ReadLine());
            customerList.AddCustomer(customer.Name);


            FlightKeeper fk = new FlightKeeper();
            DateTime departure = new DateTime(2019, 6, 1, 7, 47, 0);
            DateTime arrival = new DateTime(2019, 6, 1, 12, 4, 0);
            Boeing plane = new Boeing();
            Flight flight = new Flight("WAW", "LIS", departure, arrival, 902.2f, plane);
            fk.Add(flight);
            departure = new DateTime(2019, 7, 1, 12, 42, 22);
            arrival = new DateTime(2019, 7, 1, 15, 14, 21);
            plane = new Boeing();
            plane.TakenSeats.Add(1, new List<string>());
            plane.TakenSeats[1].Add("A");
            plane.TakenSeats[1].Add("C");
            flight = new Flight("WAW", "LON", departure, arrival, 732.5f, plane);
            fk.Add(flight);
            departure = new DateTime(2019, 7, 1, 08, 22, 22);
            arrival = new DateTime(2019, 7, 1, 09, 15, 13);
            Airbus plane2 = new Airbus();
            plane2.TakenSeats.Add(10, new List<string>());
            plane2.TakenSeats[10].Add("A");
            plane2.TakenSeats[10].Add("B");
            flight = new Flight("WAW", "GDA", departure, arrival, 412.5f, plane2);
            fk.Add(flight);
            Console.WriteLine(fk.ToString());

            Console.WriteLine($"Hi {customer.Name}!");
            Console.WriteLine("Choose your flight");


            string choosenFlight = Console.ReadLine();
            foreach (var fly in fk.flightList)
            {
                if (fly.flightId == choosenFlight)
                {
                    fly.plane.PrintSeats();
                }
            }
            Console.WriteLine("Choose your seat (seats marked with 'X' are taken");
            customer.BookFlight(flight);
            plane2.TakenSeats.Add(9, new List<string>());
            plane2.TakenSeats[9].Add("A");
            foreach (var fly in fk.flightList)
            {
                if (fly.flightId == choosenFlight)
                {
                    fly.plane.PrintSeats();
                }
            }
            foreach (var item in customer.BookedFlights)
            {
                Console.WriteLine(item.flightId);
            }
            Console.ReadLine();
        }
    }
}
