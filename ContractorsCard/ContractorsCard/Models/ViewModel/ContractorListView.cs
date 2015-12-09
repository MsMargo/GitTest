using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractorsCard.Models.ViewModel
{
    public class ContractorListView
    {
        public int Id { get; set; }
        public string ContractorName { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Nip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}