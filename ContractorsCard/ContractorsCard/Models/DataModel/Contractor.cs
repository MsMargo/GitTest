using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContractorsCard.Models.DataModel
{
    [Table("Contractors")]
    public class Contractor
    {
        public int Id { get; set; }
        public string ContractorName { get; set; }
        public string Country { get; set; }
        [Column("ZIP")]
        public string Zip { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Housing { get; set; }
        [Column("NIP")]
        public string Nip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}