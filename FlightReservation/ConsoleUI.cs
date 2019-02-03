using System;

namespace FlightReservation
{
    public static class ConsoleUI
    {
        public static void PrintStartMenu()
        {
            Console.WriteLine("Hello! Choose your action:");
            Console.WriteLine("1. Add new customer");
            Console.WriteLine("2. Choose existing customer");
        }

        public static int AskForInteger()
        {
            string input = Console.ReadLine();
            while (!Validator.CheckIfInteger(input))
            {
                Console.WriteLine("Input must be an integer");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public static string AskForNewCustomerName()
        {
            Console.WriteLine("Enter customer name:");
            string input = Console.ReadLine();
            bool askAgain = true;
            do
            {
                while (Validator.CheckIfEmptyString(input) || Validator.CheckIfNumeric(input))
                {
                    Console.WriteLine("Customer name cannot be empty or be numeric");
                    input = Console.ReadLine();
                }
                foreach (Customer customer in CustomerList.customerList)
                {
                    if (customer.Name == input)
                    {
                        Console.WriteLine("Customer name is already in database. Choose another one");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        askAgain = false;
                    }
                }

            } while (askAgain);
            return input;
        }

        public static string AskForExistingCustomerName()
        {
            Console.WriteLine("Choose existing name:");
            foreach (Customer customer in CustomerList.customerList)
            {
                Console.WriteLine(customer.Name);
            }
            string input = Console.ReadLine();
            do
            {
                while (Validator.CheckIfEmptyString(input) || Validator.CheckIfNumeric(input))
                {
                    Console.WriteLine("Customer name cannot be empty or be numeric");
                    input = Console.ReadLine();
                }
                foreach (Customer customer in CustomerList.customerList)
                {
                    if (customer.Name == input)
                    {
                        return input;
                    }
                }
                Console.WriteLine("Provided customer name doesn't exist in the database");
                input = Console.ReadLine();
            } while (true);
        }

        public static string AskForExistingFlight()
        {
            Console.WriteLine("Choose existing flight:");
            string input = Console.ReadLine();
            do
            {
                while (Validator.CheckIfEmptyString(input) || Validator.CheckIfNumeric(input))
                {
                    Console.WriteLine("Flight name cannot be empty or be numeric");
                    input = Console.ReadLine();
                }
                foreach (Flight flight in FlightKeeper.flightList)
                {
                    if (flight.flightId == input)
                    {
                        return input;
                    }
                }
                Console.WriteLine("Provided flight ID doesn't exist in the database");
                input = Console.ReadLine();
            } while (true);
        }

        public static string AskForSeatNumber(Flight flight)
        {
            Console.WriteLine("Choose your seat number (for example: A10)");
            Console.WriteLine("Seats marked with 'X' are taken");
            string input = Console.ReadLine().ToUpper();
            do
            {
                while (Validator.CheckIfEmptyString(input) || Validator.CheckIfNumeric(input))
                {
                    Console.WriteLine("Flight name cannot be empty or be all numeric");
                    input = Console.ReadLine().ToUpper();
                }
                if (input.Length > 1 &&
                    flight.plane.SeatNames.Contains(input.Substring(0, 1)) &&
                    Validator.CheckIfNumeric(input.Substring(1, input.Length - 1)))
                {
                    if (Validator.CheckIfSeatAlreadyTaken(input, flight))
                    {
                        Console.WriteLine($"Seat {input} is already taken");
                        input = Console.ReadLine().ToUpper();
                    }
                    else
                    {
                        return input;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Wrong format");
                    input = Console.ReadLine().ToUpper();
                }
               
            } while (true);
        }
    }
}