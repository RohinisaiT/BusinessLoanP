using System;
using System.Collections.Generic;
using System.IO;
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
        public DocumentsRepository documentsRepository;

        public LoanController()
        {
            loanRepository = new LoanRepository();
            documentsRepository = new DocumentsRepository();
        }

        [HttpGet]
        public ActionResult AddDocument()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDocument([Bind(Include = "documentId, documentType, documentUpload")] Document document, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                if(postedFile != null)
                {
                    int fileLength = postedFile.ContentLength;
                    byte[] fileBuffer = new byte[fileLength];

                    LoanApplicant loan = (LoanApplicant)Session["loan"];

                    postedFile.InputStream.Read(fileBuffer, 0, fileLength);

                    document.documentType = postedFile.ContentType;
                    document.documentUpload = fileBuffer;

                    loanRepository.ApplyLoan(loan, document);

                    ViewBag.Message = "Uploaded Successfully";

                    return RedirectToAction("getLoans");
                }
            }
            ViewBag.Message = "Upload Failed..!!";
            return View();
        }


        [HttpGet]
        public ActionResult getLoans()
        {
            List<LoanApplicant> loans = loanRepository.viewLoan();
            return View(loans);
        }

        [HttpGet]
        public ActionResult addLoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addLoan(LoanApplicant loan)
        {
            loan.loanType = "Normal";
            loan.LoanRepaymentMethod = "None";
            loan.TimestampofLoan = DateTime.Now.ToString("T");

            Session["loan"] = loan;

            return RedirectToAction("addDocument");
        }

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
        [HttpPut]
        [Route("updateStatus")]
        public string updateStatus(int id, Boolean val, Object obj)
        {
            LoanApplicant loanApplicant = loanRepository.LoanApplicant.Find(id);
            if (val == true)
            {
                loanApplicant.TimestampofLoan = DateTime.Now.ToString("MMMM-dd-yyyy");
            }
            else
            {
                loanApplicant.TimestampofLoan = "0";
            }
            db.Entry(loanApplicant).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "status updated";
        }
    }
}