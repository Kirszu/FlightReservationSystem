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
    }
}