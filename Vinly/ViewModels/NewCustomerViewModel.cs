using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinly.Models;

namespace Vinly.ViewModels
{
    public class CustomerFormViewModel
    { 
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
        public string PageTitle
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edit Customer";
                return "New Customer";
            }
        }


}

    }
