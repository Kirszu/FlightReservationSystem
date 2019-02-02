using System.Collections.Generic;
namespace FlightReservation
{
    public static class CustomerList
    {
        public static List<Customer> customerList = new List<Customer>();

        public static void AddCustomer(Customer customer)
        {
            customerList.Add(customer);
        }
    }
}