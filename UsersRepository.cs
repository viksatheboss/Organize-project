using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebShopProjectDomainModels;


namespace WebShopProjectRepositories
{
    public interface IUsersRepository
    {
        void InsertUser(User u);
        void UpdateUserDetails(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(int uid);
        List<User> GetUsers();
        List<User> GetUsersByEmailAndPassword(string Email, string Password);
        List<User> GetUsersByEmail(string Email);
        List<User> GetUsersByUserId(int UserId);
        int GetLatestUserId();
    }
    public class UsersRepository : IUsersRepository
    {
        WebShopDatabaseDbContext db;

        public UsersRepository()
        {
            db = new WebShopDatabaseDbContext();
        }

        public void InsertUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUserDetails(User u)
        {
            User us = db.Users.Where(temp => temp.UserId == u.UserId).FirstOrDefault();
            if(us != null)
            {
                us.Name = u.Name;
                us.Mobile = u.Name;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(User u)
        {
            User us = db.Users.Where(temp => temp.UserId == u.UserId).FirstOrDefault();
            if (us != null)
            {
                us.PasswordHash = u.PasswordHash;
                db.SaveChanges();
            }
        }

        public void DeleteUser(int uid)
        {
            User us = db.Users.Where(temp => temp.UserId == uid).FirstOrDefault();
            if (uid != 0)
            {
                db.Users.Remove(us);
                db.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            List<User> us = db.Users.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.Name).ToList();
            return us;
        }

        public List<User> GetUsersByEmailAndPassword(string Email, string PasswordHash)
        {
            List<User> us = db.Users.Where(temp => temp.Email == Email && temp.PasswordHash== PasswordHash).ToList();
            return us;
        }

        public List<User> GetUsersByEmail(string Email)
        {
            List<User> us = db.Users.Where(temp => temp.Email == Email).ToList();
            return us;
        }

        public List<User> GetUsersByUserId(int UserId)
        {
            List<User> us = db.Users.Where(temp => temp.UserId == UserId).ToList();
            return us;
        }

        public int GetLatestUserId()
        {
            int uid = db.Users.Select(temp => temp.UserId).Max();
            return uid;
        }

        
    }
}
