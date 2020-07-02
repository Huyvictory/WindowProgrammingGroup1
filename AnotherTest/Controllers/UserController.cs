using AnotherTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnotherTest.Controllers;
using System.Data.Entity.Migrations;

namespace AnotherTest.Controllers
{
    class UserController
    {
        public static bool DeleteUser(string username)
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var user = (from u in _context.Users
                            where u.username == username
                            select u).SingleOrDefault();
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
        }
        public static User getExistUsername(string username)
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var user = from u in _context.Users
                           where u.username == username
                           select u;
                if (user.Count() == 1)
                {
                    return user.Single();
                }
                else return null;

            }
        }
        public static bool checkExistUsername(string username)
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var user = from u in _context.Users
                           where u.username == username
                           select u;
                if (user.Count() == 1)
                {
                    return true;
                }
                else return false;

            }
        }
        public static bool addUser(User user)
        {
            try
            {
                using (var _context = new DBReadingProgramEntities())
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static List<User> GetallUsers()
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var user = (from u in _context.Users.AsEnumerable()
                            select new
                            {
                                id = u.id,
                                username = u.username,
                                password = u.password,
                                name = u.name,
                                birthday = u.birthday,
                                email = u.email,
                                phone = u.phone
                            }).Select(x => new User
                            {
                                id = x.id,
                                username = x.username,
                                password = x.password,
                                name = x.name,
                                birthday = x.birthday,
                                email = x.email,
                                phone = x.phone
                            });
                return user.ToList();
            }
        }
        public static bool updateUser(User useradd)
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var user = (from u in _context.Users
                            where u.username == useradd.username
                            select u).SingleOrDefault();
                user.name = useradd.name;
                user.phone = useradd.phone;
                user.email = useradd.email;
                user.birthday = useradd.birthday;
                _context.Users.AddOrUpdate(user);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool Changepass(User mainuser,string pass)
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var user = (from u in _context.Users
                            where u.username == mainuser.username
                            select u).SingleOrDefault();
                user.password = pass;
                _context.Users.AddOrUpdate(user);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
