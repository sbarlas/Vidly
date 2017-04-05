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

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };


                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                customer.IsActive = true;
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

               // TryUpdateModel(customerInDb);
                
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {

            var customerDetails = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerDetails == null)
            {
                return HttpNotFound("Can not find customer");
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customerDetails,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            
            return View("CustomerForm", viewModel);
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
