using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCoreMVCConcepts.Models
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
    }
}
