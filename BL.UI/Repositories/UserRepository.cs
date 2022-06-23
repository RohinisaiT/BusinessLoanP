using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DataService;
namespace BL.UI.Repositories
{
    public class UserRepository
    {
        public BusinessLoanEntities dbEntities;
        public UserRepository()
        {
            dbEntities = new BusinessLoanEntities();
        }
        public void addUser(User user)
        {
            dbEntities.Users.Add(user);
            dbEntities.SaveChanges();
        }
        public void EditUser(User user)
        {
            dbEntities.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            dbEntities.SaveChanges();
        }
        public void DeleteUser(string userId)
        {
            User user = dbEntities.Users.Find(userId);
            dbEntities.Users.Remove(user);
            dbEntities.SaveChanges();
        }
        public User GetUserById(string userId)
        {
            User user = dbEntities.Users.Find(userId);
            return user;
        }
        public List<User> GetUsers()
        {
            return dbEntities.Users.ToList();
        }
    }
}