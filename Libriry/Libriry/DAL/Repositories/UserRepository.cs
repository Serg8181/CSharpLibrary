﻿using Library.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    internal class UserRepository : IUser
    {
        private AppContext db; 
        public UserRepository(AppContext context)
        {
            db = context;
        }
        public int Create(User user)
        {
           db.Users.Add(user);
           return db.SaveChanges();
        }

        public int Delete(User user)
        {
            db.Users.Remove(user);
            return db.SaveChanges();
        }

        public IEnumerable<User> FindAll()
        {
            return db.Users.ToList();
        }

        public User FindById(int id)
        { 
            return db.Users.Where(user => user.Id == id).FirstOrDefault();
        }

        public int UpdateName(int id, string name)
        {
            var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
            user.Name = name;
            return db.SaveChanges();
        }
    }
}
