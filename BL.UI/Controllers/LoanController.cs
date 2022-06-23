using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.DataService;
using BL.UI.Repositories;

namespace BL.UI.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public LoanRepository loanRepository;
       
        public LoanController()
        {
            loanRepository = new LoanRepository();
        }
        public ActionResult getLoan(LoanApplicant loan)
        {
            List<LoanApplicant> loans =loanRepository.viewLoan();
            return View(loans);
        }
        public ActionResult addLoan(LoanApplicant loan)
        {
            loanRepository.ApplyLoan(loan) ;
            return RedirectToAction("getLoan");
        }
        public ActionResult editLoan(LoanApplicant data)
        {
            loanRepository.editLoan(data);
            return View(data);
        }
        public ActionResult deleteLoan(int loanid)
        {
            loanRepository.deleteLoan(loanid);
            return RedirectToAction("getLoan");
        }
    }
}