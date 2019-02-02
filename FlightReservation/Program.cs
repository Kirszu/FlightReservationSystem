using System;
using System.Collections.Generic;

namespace FlightReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerList.AddCustomer(new Customer("Scott"));
            CustomerList.AddCustomer(new Customer("Anna"));
            ConsoleUI.PrintStartMenu();
            int input = ConsoleUI.AskForInteger();
            bool askAgain = true;
            string customerName = "";
            Customer customer = new Customer("");
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


            DateTime departure = new DateTime(2019, 6, 1, 7, 47, 0);
            DateTime arrival = new DateTime(2019, 6, 1, 12, 4, 0);
            Boeing plane = new Boeing();
            Flight flight = new Flight("WAW", "LIS", departure, arrival, 902.2f, plane);
            FlightKeeper.Add(flight);
            departure = new DateTime(2019, 7, 1, 12, 42, 22);
            arrival = new DateTime(2019, 7, 1, 15, 14, 21);
            plane = new Boeing();
            plane.TakenSeats.Add(1, new List<string>());
            plane.TakenSeats[1].Add("A");
            plane.TakenSeats[1].Add("C");
            flight = new Flight("WAW", "LON", departure, arrival, 732.5f, plane);
            FlightKeeper.Add(flight);
            departure = new DateTime(2019, 7, 1, 08, 22, 22);
            arrival = new DateTime(2019, 7, 1, 09, 15, 13);
            Airbus plane2 = new Airbus();
            plane2.TakenSeats.Add(9, new List<string>());
            plane2.TakenSeats[9].Add("A");
            flight = new Flight("WAW", "GDA", departure, arrival, 412.5f, plane2);
            FlightKeeper.Add(flight);

            Console.WriteLine(FlightKeeper.ToString());       
            Console.WriteLine("Choose your flight");

            string choosenFlight = ConsoleUI.AskForExistingFlight();
            flight = FlightKeeper.flightList.Find(fly => fly.flightId == choosenFlight);
            flight.plane.PrintSeats();

            string seatId = ConsoleUI.AskForSeatNumber(flight);
            string seatLetter = seatId.Substring(0, 1).ToUpper();
            int seatRow = int.Parse(seatId.Substring(1, seatId.Length - 1));

            customer.BookFlight(flight);
            if (!flight.plane.TakenSeats.ContainsKey(seatRow)){
                flight.plane.TakenSeats.Add(seatRow, new List<string>()); //Check if key is in dictionary
            }
            flight.plane.TakenSeats[seatRow].Add(seatLetter);
            foreach (var fly in FlightKeeper.flightList)
            {
                if (fly.flightId == choosenFlight)
                {
                    fly.plane.PrintSeats();
                }
            }
            foreach (var bookedFlight in customer.BookedFlights)
            {
                if (bookedFlight.flightId == flight.flightId) {
                    bookedFlight.bookedSeats.Add(seatId);   //Adding seat number to customers booked ticket
                }
            }
            foreach (var item in customer.BookedFlights)
            {
                Console.WriteLine(item.flightId);
                foreach (var bookedSeat in item.bookedSeats)  //Printing seat number of customers booked ticket
                {
                    Console.WriteLine(bookedSeat);
                }
            }
            Console.ReadLine();
        }
    }
}
