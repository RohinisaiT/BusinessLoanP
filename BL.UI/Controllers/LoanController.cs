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
        BusinessLoanEntities db = new BusinessLoanEntities();

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
                    postedFile.InputStream.Read(fileBuffer, 0, fileLength);

                    document.documentType = postedFile.ContentType;
                    document.documentUpload = fileBuffer;

                    documentsRepository.addDocuments(document);

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
            try
            {
                Random r = new Random();
                int genRand = r.Next(1000, 9999);

                while (db.Documents.Any(o => o.documentId == genRand))
                {
                    genRand = r.Next(1000, 9999);
                }

                loan.documentId = genRand;
                loan.loanType = "Normal";
                loan.LoanRepaymentMethod = "None";
                loan.TimestampofLoan = DateTime.Now.ToString("T");

                loanRepository.ApplyLoan(loan);

                return RedirectToAction("addDocument");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;

                //return RedirectToAction("getLoans");
            }
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
        

    }
}