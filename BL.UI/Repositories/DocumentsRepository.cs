using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DataService;

namespace BL.UI.Repositories
{
    public class DocumentsRepository
    {
        public BusinessLoanEntities dbEntities;
        public DocumentsRepository()
        {
            dbEntities = new BusinessLoanEntities();
        }
        public void addDocuments()
        {


        }
        public void viewDocuments()
        {

        }
        public void editDocuments(Document documentId)
        {

        }
        public void deleteDocuments(Document documentId)
        {

        }
    }
}