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
        public void ApplyLoan(LoanApplicant data, Document docs)
        {
            dbEntities.Documents.Add(docs);
            dbEntities.LoanApplicants.Add(data);
            dbEntities.SaveChanges();
        }
        public List<LoanApplicant> viewLoan()
        {
            return dbEntities.LoanApplicants.ToList();
        }
        public void editLoan(LoanApplicant loan)
        {
            dbEntities.Entry<LoanApplicant>(loan).State = System.Data.Entity.EntityState.Modified;
            dbEntities.SaveChanges();
        }
        public void deleteLoan(int loanId)
        {
            User user = dbEntities.Users.Find(loanId);
            dbEntities.Users.Remove(user);
            dbEntities.SaveChanges();
        }
        public bool LoanStatus(LoanApplicant loanId)
        {
            User
        }
       

    }

}