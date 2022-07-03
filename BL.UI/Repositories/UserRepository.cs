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
            Login login = new Login();
            login.email = user.email;
            login.password = user.password;

            dbEntities.Users.Add(user);
            dbEntities.SaveChanges();

            dbEntities.Logins.Add(login);
            dbEntities.SaveChanges();
        }
        public void EditUser(User user)
        {
            dbEntities.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            dbEntities.SaveChanges();
        }
        public void DeleteUser(int userId)
        {

            User user = dbEntities.Users.Find(userId);

            Login login = dbEntities.Logins.Find(user.email);

            dbEntities.Logins.Remove(login);
            dbEntities.SaveChanges();
    
            dbEntities.Users.Remove(user);
            dbEntities.SaveChanges();
        }
        public User GetUserById(int userId)
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