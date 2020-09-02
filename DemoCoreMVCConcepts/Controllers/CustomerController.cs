using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCoreMVC.Data.Data;
using DemoCoreMVCConcepts.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoCoreMVCConcepts.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CoreMVCContext _dbcontext;
        private readonly ICustomerService _customerService;

        public CustomerController(CoreMVCContext context, ICustomerService customerService)
        {
            _dbcontext = context;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerInformation()
        {
            var customer = new Customer
            {
                Name = "Satya",
                Age = 25,
                address = new Address
                {
                    StreetName = "16 downey Drive",
                    AddressLine1 = "Gold Building",
                    AddressLine2 = "Construction Plaza",
                    City = "Manhatten",
                    State = "Newyork",
                    PinCode = "10012"
                }
            };
            return View(customer);
        }

        [HttpGet]
        public IActionResult CustomerAddress()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CustomerAddress(Address address)
        {
            if(address is { })
            {
                _dbcontext.Addresses.Add(address);                
                _dbcontext.SaveChanges();
                return RedirectToAction("CustomerInformation");
            }
            return View();
        }

        [HttpPut]
        public IActionResult UpdateAddress(Address address)
        {
            //Code to update Address
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteAddress(int? id)
        {
            if(id != 0)
            {
                Address address = _dbcontext.Addresses.Where(ad => ad.Id == id.GetValueOrDefault()).SingleOrDefault();
                _dbcontext.Addresses.Remove(address);
                _dbcontext.SaveChanges();
                return RedirectToAction("CustomerInformation");
            }
            return NotFound();
        }

    }
}
