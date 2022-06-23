using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DataService;

namespace BL.UI.Repositories
{
    public class LoanRepository
    {
        public BusinessLoanEntities dbEntities;
        public LoanRepository()
        {
            dbEntities = new BusinessLoanEntities();
        }
        public void ApplyLoan(LoanApplicant data)
        {

        }
        public void viewLoan(LoanApplicant data)
        {

        }
        public void editLoan(LoanApplicant loanId)
        {

        }
        public void deleteLoan(LoanApplicant loanId)
        {

        }
    }
        
}