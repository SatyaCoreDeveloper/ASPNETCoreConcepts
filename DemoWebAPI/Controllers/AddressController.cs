using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCoreMVCConcepts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/Address")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Address> GetAddresses()
        {            
            var addresses = new List<Address>() { 
                new Address 
                { 
                    StreetName = "Test street",
                    AddressLine1 = "Line1",
                    State = "Delhi",
                    PinCode = "1001001"
                } };
            return addresses;
        }

    }
}
