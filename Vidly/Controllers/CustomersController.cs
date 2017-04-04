using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customerList = GetStaticCustomerList();

            return View(customerList);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customerList = GetStaticCustomerList();

            var customer = customerList.Find(x => x.Id == id);

            if(customer == null)
            {
                return HttpNotFound("Customer does not exist");
            }
            return View(customer);
        }

        private List<Customer> GetStaticCustomerList()
        {
            var customerList = new List<Customer>()
            {
                new Customer { Id=1, Age=21, IsActive=true, Name="Sarah Smith" },
                new Customer { Id=2, Age=25, IsActive=true, Name="Charlie Arnott" },
            };

            return customerList;
        }
    }
}
