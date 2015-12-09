using ContractorsCard.Models.ViewModel;
using ContractorsCard.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContractorsCard.Controllers
{
    public class ContractorController : Controller
    {
        public ActionResult List()
        {
            ContractorService service = new ContractorService();
            var model = service.GetContractorList();
            return View(model);
        }
        public ActionResult New()
        {
            var model = new NewOrEditContractorView();
            return View(model);
        }
        [HttpPost]
        public ActionResult New(NewOrEditContractorView contractor)
        {
            ContractorService service = new ContractorService();
            if (ModelState.IsValid)
            {
                service.AddOrEdit(contractor);
                return RedirectToAction("List");
            }
            return View();
        }
        public ActionResult Edit(int Id)
        {
            ContractorService service = new ContractorService();
            var model = service.GetContractorById(Id);
            return View("New", model);
        }
        [HttpPost]
        public ActionResult Edit(NewOrEditContractorView contractor)
        {
            ContractorService service = new ContractorService();
            if (ModelState.IsValid)
            {
                service.AddOrEdit(contractor);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}