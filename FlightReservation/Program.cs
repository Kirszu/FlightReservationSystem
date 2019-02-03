using System;
using System.Collections.Generic;

namespace FlightReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime departure = new DateTime(2019, 6, 1, 7, 47, 0);
            DateTime arrival = new DateTime(2019, 6, 1, 12, 4, 0);
            IPlane plane = new Boeing();
            Flight flight = new Flight("WAW", "LIS", departure, arrival, 902.2f, plane);
            FlightKeeper.Add(flight);
            departure = new DateTime(2019, 7, 1, 12, 42, 22);
            arrival = new DateTime(2019, 7, 1, 15, 14, 21);
            plane = new Boeing();
            plane.AddTakenSeat("A9");
            plane.AddTakenSeat("B10");
            flight = new Flight("WAW", "LON", departure, arrival, 732.5f, plane);
            FlightKeeper.Add(flight);
            departure = new DateTime(2019, 7, 1, 08, 22, 22);
            arrival = new DateTime(2019, 7, 1, 09, 15, 13);
            IPlane plane2 = new Airbus();
            plane2.AddTakenSeat("A9");
            plane2.AddTakenSeat("B9");
            flight = new Flight("WAW", "GDA", departure, arrival, 412.5f, plane2);
            FlightKeeper.Add(flight);

            CustomerList.AddCustomer(new Customer("Scott"));
            CustomerList.AddCustomer(new Customer("Anna"));

            string customerName = "";
            Customer customer = new Customer("");
            while (true)
            {
                ConsoleUI.PrintStartMenu();
                int input = ConsoleUI.AskForInteger();
                bool askAgain = true;
                do
                    switch (input)
                    {
                        case 1:
                            customerName = ConsoleUI.AskForNewCustomerName();
                            customer = new Customer(customerName);
                            CustomerList.AddCustomer(customer);
                            askAgain = false;
                            break;
                        case 2:
                            customerName = ConsoleUI.AskForExistingCustomerName();
                            customer = CustomerList.customerList.Find(cust => cust.Name == customerName);
                            askAgain = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect choice");
                            input = ConsoleUI.AskForInteger();
                            break;
                    } while (askAgain);
                Console.WriteLine($"Hi {customer.Name}!");

                Console.WriteLine(FlightKeeper.ToString());
                Console.WriteLine("Choose your flight");

                string choosenFlight = ConsoleUI.AskForExistingFlight();
                flight = FlightKeeper.flightList.Find(fly => fly.flightId == choosenFlight);
                flight.plane.PrintSeats();

                string seatId = ConsoleUI.AskForSeatNumber(flight);
                flight.plane.AddTakenSeat(seatId);
                customer.BookFlight(flight, seatId);
                flight.plane.PrintSeats();

                Console.WriteLine($"Customer name: {customer.Name}");
                foreach (var item in customer.BookedFlights)
                {
                    Console.WriteLine(item.Key.flightId);
                    foreach (var temp in item.Value)
                    {
                        Console.WriteLine(temp);
                    }
                }
                Console.WriteLine("Next turn");
                Console.ReadLine();
            } 
        }
    }
}
