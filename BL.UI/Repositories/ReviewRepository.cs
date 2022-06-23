using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DataService;

namespace BL.UI.Repositories
{
    public class ReviewRepository
    {
        public BusinessLoanEntities dbEntities;
        public ReviewRepository()
        {
            dbEntities = new BusinessLoanEntities();
        }
    }
}