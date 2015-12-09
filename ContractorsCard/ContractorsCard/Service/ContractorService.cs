using ContractorsCard.Models;
using ContractorsCard.Models.DataModel;
using ContractorsCard.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractorsCard.Service
{
    public class ContractorService
    {
        ContractorDBContext db = new ContractorDBContext();
        public IEnumerable<ContractorListView> GetContractorList()
        {
            var dbContractors = db.Contractors.ToList();

            List<ContractorListView> contractorsList = dbContractors.Select(x => new ContractorListView
            {
                Address = String.Format("{0} {1}{2}", x.Street, x.HouseNumber, x.Housing == null ? String.Empty : String.Format(" {0}", x.Housing)),
                City = x.City,
                ContractorName = x.ContractorName,
                Country = x.Country,
                Email = x.Email,
                Nip = x.Nip,
                PhoneNumber = x.PhoneNumber,
                Zip = x.Zip,
                Id = x.Id
            }).ToList();
            return contractorsList;
        }
        public void AddOrEdit(NewOrEditContractorView contractor)
        {
            if (contractor.Id != 0)
            {
                var dbContractor = db.Contractors.FirstOrDefault(x => x.Id == contractor.Id);
                if (dbContractor != null)
                {
                    dbContractor.City = contractor.City;
                    dbContractor.ContractorName = contractor.ContractorName;
                    dbContractor.Country = contractor.Country;
                    dbContractor.Email = contractor.Email;
                    dbContractor.HouseNumber = Int32.Parse(contractor.HouseNumber);
                    dbContractor.Housing = contractor.Housing;
                    dbContractor.Nip = contractor.Nip;
                    dbContractor.PhoneNumber = contractor.PhoneNumber;
                    dbContractor.Street = contractor.Street;
                    dbContractor.Zip = contractor.Zip;

                    db.SaveChanges();
                }
            }
            else
            {
                db.Contractors.Add(new Contractor
                {
                    City = contractor.City,
                    ContractorName = contractor.ContractorName,
                    Country = contractor.Country,
                    Email = contractor.Email,
                    HouseNumber = Int32.Parse(contractor.HouseNumber),
                    Housing = contractor.Housing,
                    Nip = contractor.Nip,
                    PhoneNumber = contractor.PhoneNumber,
                    Street = contractor.Street,
                    Zip = contractor.Zip
                });
                db.SaveChanges();
            }
        }
        public NewOrEditContractorView GetContractorById(int id)
        {
            var dbContractor = db.Contractors.FirstOrDefault(x => x.Id == id);
            var contractrorView = new NewOrEditContractorView();
            if (dbContractor != null)
            {
                contractrorView.Street = dbContractor.Street;
                contractrorView.HouseNumber = dbContractor.HouseNumber.ToString();
                contractrorView.Housing = dbContractor.Housing;
                contractrorView.City = dbContractor.City;
                contractrorView.ContractorName = dbContractor.ContractorName;
                contractrorView.Country = dbContractor.Country;
                contractrorView.Email = dbContractor.Email;
                contractrorView.Nip = dbContractor.Nip;
                contractrorView.PhoneNumber = dbContractor.PhoneNumber;
                contractrorView.Zip = dbContractor.Zip;
            }
            return contractrorView;
        }
    }
}