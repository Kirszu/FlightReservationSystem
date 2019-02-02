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
            while (!Validator.CheckInputIfInteger(input))
            {
                Console.WriteLine("Input must be an integer");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }

        public static string AskForNewCustomerName()
        {
            string input = Console.ReadLine();
            bool askAgain = true;
            do
            {
                while (Validator.CheckInputIfEmptyString(input) || Validator.CheckInputIfNumeric(input))
                {
                    Console.WriteLine("Customer name cannot be empty or be numeric");
                    input = Console.ReadLine();
                }

                if (CustomerList.customerList.Contains(input))
                {
                    Console.WriteLine("Customer name is already in database. Choose another one");
                    input = Console.ReadLine();
                } 
                else
                {
                    askAgain = false;
                }
            } while (askAgain);
            return input;
        }
    }
}