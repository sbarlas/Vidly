using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }

        public string Title
        {
            get
            {
                return (IsNewCustomereForm) ? "New Customer" : "Edit Customer";
            }
        }

        public bool IsNewCustomereForm
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return false;
                }

                return true;

            }
        }
    }
}