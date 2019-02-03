using System;

namespace FlightReservation
{
    public static class Validator
    {


        public static bool CheckIfInteger(string input)
        {
            int number;
            if (!int.TryParse(input, out number))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckIfDouble(string input)
        {
            double number;
            if (!double.TryParse(input, out number))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckIfNumeric(string test)
        {
            int i;
            return int.TryParse(test, out i);
        }

        public static bool CheckIfEmptyString(string test)
        {
            return test == "" ? true : false;
        }

        internal static bool CheckIfSeatAlreadyTaken(string input, Flight flight)
        {
            int seatRow = int.Parse(input.Substring(1, input.Length - 1));
            string seatLetter = input.Substring(0, 1);
            if (!flight.plane.TakenSeats().ContainsKey(seatRow))
            {
                return false;
            } 
            else
            {
                if (flight.plane.TakenSeats()[seatRow].Contains(seatLetter))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}