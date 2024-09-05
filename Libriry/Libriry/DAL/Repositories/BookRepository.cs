using Library.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    internal class BookRepository : IBook
    {
        private AppContext db;

        public BookRepository(AppContext app)
        { 
            db = app;        
        }

        public int Create(Book book)
        {           
            db.Books.Add(book);
            return db.SaveChanges();            
        }

        public int Delete(Book book)
        {
            db.Books.Remove(book);
            return db.SaveChanges();
        }

        public IEnumerable<Book> FindAll()
        {
            return db.Books.ToList();
        }

        public Book FindById(int id)
        {
            var book = db.Books.Where(book => book.Id == id).FirstOrDefault();

            if (book == null) 
            {
                Console.WriteLine($"Книга с ID {id} не существует.");
                return null;
            } 
            return book;
        }
         

        public bool UpdateYear(int id , int year)
        {
            var book = db.Books.Where(book => book.Id == id).FirstOrDefault();
            if (book == null)
            {
                Console.WriteLine($"Книга с ID {id} не существует.");
                return false;
            }
            book.Year = year;
            db.SaveChanges();
            return true;
        }

        public List<Book> SearchBookGenreAndYears(string genre, int startYear, int endYear)
        {           
            var query = db.Books.Where(x=>x.Genre == genre).Where(x=>x.Year >= startYear && x.Year <= endYear); 
            
            return query.ToList();
        }

        public int CountSearchBookAuthor(string author)
        {
           var query = db.Books.Count(x=>x.Author == author);
            return query;
        }

        public int CountSearchBookGenre(string genre)
        {
            var query = db.Books.Count(x => x.Genre == genre);
            return query;
        }

        public bool IsBookAuthorTitle(string author, string title)
        {
            var query = db.Books.Where(x=>x.Author == author).Where(x => x.Title == title).FirstOrDefault();
            if(query != null) return true;
            return false;

        }

        public Book LatestBookPublished()
        {
            int lastYear = db.Books.Max(x => x.Year);
            var query = db.Books.Where(x => x.Year == lastYear).FirstOrDefault();
            if(query != null) return query;

            Console.WriteLine("Последняя опубликованная книга не найдена.");
            return null;
        }

        public List<Book> GetSortTitleBooks()
        {
            return db.Books.OrderBy(x=>x.Title).ToList();
           
        }

        public List<Book> GetSortYearBooks()
        {
            var list = db.Books.OrderBy(x => x.Year).ToList();
            list.Reverse();
            return list;
        }
    }
}
