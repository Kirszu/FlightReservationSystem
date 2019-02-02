using System;

namespace FlightReservation
{
    public static class Validator
    {


        public static bool CheckInputIfInteger(string input)
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
        public static bool CheckInputIfDouble(string input)
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
        public static bool CheckInputIfNumeric(string test)
        {
            int i;
            return int.TryParse(test, out i);
        }

        public static bool CheckInputIfEmptyString(string test)
        {
            return test == "" ? true : false;
        }
    }
}