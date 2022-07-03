using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.DataService;
using BL.UI.Repositories;

namespace BL.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public LoanRepository loanRepository;
        public AdminController()
        {
            loanRepository = new LoanRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        /*public ActionResult ApproveLoan(LoanApplicant obj)
        {

        }
        public ActionResult verifyDocuments(Document doc)
        {

        }*/
        [HttpPut]
        public ActionResult editLoan(LoanApplicant data)
        {
            loanRepository.editLoan(data);
            return View(data);
        }

        [HttpDelete]
        public ActionResult deleteLoan(int loanid)
        {
            loanRepository.deleteLoan(loanid);
            return RedirectToAction("getLoans");
        }

    }
}