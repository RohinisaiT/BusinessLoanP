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
        public void addDocuments(Document document)
        {
            dbEntities.Documents.Add(document);
            dbEntities.SaveChanges();
        }
        public void editDocuments(Document document)
        {
            dbEntities.Entry<Document>(document).State = System.Data.Entity.EntityState.Modified;
            dbEntities.SaveChanges();
        }
        public void deleteDocuments(string documentId)
        {
            Document document = dbEntities.Documents.Find(documentId);
            dbEntities.Documents.Remove(document);
            dbEntities.SaveChanges();
        }
        public List<Document> viewDocuments()
        {
            return dbEntities.Documents.ToList();
        }
    }
}