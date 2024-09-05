using Library.BLL.Models;
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
            var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            Console.WriteLine($"Пользователь с ID {id} не найден.");
            return null;
        }

        public bool UpdateName(int id, string name)
        {
            var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
            if ((user != null))
            {
                user.Name = name;
                db.SaveChanges();
                return true;
            }

            return false;
        }
        public void UserTakeBook(int id , Book book)
        {
                       
            var myUser = db.Users.Where(x=>x.Id == id).FirstOrDefault();           
            book.UserId = myUser.Id;
            book.User = myUser;
            myUser.Books.Add(book);
            db.SaveChanges();
        }

        public bool IsBookUserHand(int id , Book book)
        {
          
            var result = db.Users.Where(x=>x.Id == id).First().Books.Contains(book);

            return result;
        
        }

        public int CountUserBook(int id)
        {
            var user =  db.Users.Where(x => x.Id == id).FirstOrDefault();  
            if(user!= null)
            {
                return user.Books.Count();
            }
            Console.WriteLine($"Пользователь с ID {id} не найден.");
            return 0;
        }

        
    }
}
