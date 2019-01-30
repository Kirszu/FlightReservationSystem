using System.Collections.Generic;
namespace FlightReservation
{
    public class CustomerList
    {
        List<string> customerList = new List<string>();

        public void AddCustomer(string name)
        {
            customerList.Add(name);
        }
    }
}