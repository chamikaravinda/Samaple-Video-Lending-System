using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinly.Models;
using Vinly.ViewModels;

namespace Vinly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _contex;

        public CustomerController() {

            _contex = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult New()
        {
            var membershipType = _contex.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                /*Below line is added because without this ID is null . 
               so when validationg modelState.Isvalid become true.so cannot savae a customer*/
                Customer = new Customer(),
                MembershipType = membershipType
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//to check encripted token
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {

                  var viewModel = new CustomerFormViewModel
                  {
                      Customer = customer,
                      MembershipType = _contex.MembershipType.ToList()

                  };

              return View("CustomerForm",viewModel);

            }

            if (customer.Id == 0)
                _contex.Customers.Add(customer);
            else
            {
                var customerInDb = _contex.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _contex.SaveChanges();
            return RedirectToAction("Index","Customer");
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _contex.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel {
                Customer = customer,
                MembershipType = _contex.MembershipType.ToList()
                

            };
            return View("CustomerForm", viewModel);
        }

    }
}