using System.Collections.Generic;
namespace FlightReservation
{
    public static class CustomerList
    {
        public static List<string> customerList = new List<string>();

        public static void AddCustomer(string name)
        {
            customerList.Add(name);
        }
    }
}