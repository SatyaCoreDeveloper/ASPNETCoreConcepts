using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCoreMVCConcepts.Models
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer
            {
                Name = "",
                address = new Address {
                    StreetName = "abc",
                    City = "Chennai",
                    State = "TN",
                    PinCode = "600000"
                },
                Age = 30
            }) ;

        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }
    }
}
