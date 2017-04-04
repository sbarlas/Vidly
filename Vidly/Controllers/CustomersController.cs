using System;
using System.Data.Entity;
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
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        /// <summary>
        /// Get cusotmers
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var customerList = _context.Customers.Include(m => m.MembershipType).ToList();

            return View(customerList);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customerList = _context.Customers.Include(m => m.MembershipType).ToList();
            var customer = customerList.SingleOrDefault(x => x.Id == id);

            if(customer == null)
            {
                return HttpNotFound("Customer does not exist");
            }
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipType
            };

            return View(viewModel);
        }

        //private List<Customer> GetStaticCustomerList()
        //{
        //    var customerList = new List<Customer>()
        //    {
        //        new Customer { Id=1, Age=21, IsActive=true, Name="Sarah Smith" },
        //        new Customer { Id=2, Age=25, IsActive=true, Name="Charlie Arnott" },
        //    };

        //    return customerList;
        //}
    }
}
