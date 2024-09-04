using Library.BLL.Models;
using Library.DAL.Repositories;

public class Program
{
    static void Main(string[] args)
    {
        using (var db = new Library.DAL.Repositories.AppContext())
        {


            var book1 = new Book { Title = "Азбука1", Year = 1980, Author ="Тютчев", Genre = "Научная литература"};
            var book2 = new Book { Title = "Азбука2", Year = 1990, Author = "Тургенев", Genre = "Фантастика" };
            var book3 = new Book { Title = "Азбука3", Year = 1999, Author = "Толстой", Genre = "Художественная литература" };
            var book4 = new Book { Title = "Азбука4", Year = 1965, Author = "Тютчев", Genre = "Научная литература" };
            var book5 = new Book { Title = "Азбука5", Year = 1991, Author = "Тургенев", Genre = "Фантастика" };
            var book6 = new Book { Title = "Азбука6", Year = 2005, Author = "Тургенев", Genre = "Фантастика" };

            var user1 = new User { Name = " Олег", Email = "oleg@mail.ru" };
            var user2 = new User { Name = " Дмитрий", Email = "dima@mail.ru" };
            var user3 = new User { Name = " Владимир", Email = "vlad@yandex.ru" };

            var bookRep = new BookRepository(db);
            var userRep = new UserRepository(db);

            userRep.Create(user1);
            userRep.Create(user2);
            userRep.Create(user3);

            bookRep.Create(book1);
            bookRep.Create(book2);
            bookRep.Create(book3);
            bookRep.Create(book4);
            bookRep.Create(book5);
            bookRep.Create(book6);


            userRep.TakeBook(user1, book2);

            Console.WriteLine("_________________________");

            if(userRep.IsBookUserHand(user1 , book2))
            {

            }

            Console.WriteLine("_________________________");
            Console.WriteLine("Книги в библиотеке: ");

            foreach (var book in bookRep.FindAll())
            {
                Console.WriteLine(book.Id + " " + book.Title + " " + book.Year);
            }
            Console.WriteLine("Пользователи библиотеки: ");

            foreach (var user in userRep.FindAll())
            {
                Console.WriteLine(user.Id + " " + user.Name + " " + user.Email);
            }
            Console.WriteLine("_________________________");

            //bookRep.Delete(book1);
            //userRep.Delete(user1);


            var mySearchBook = bookRep.FindById(2);
            var myserchUser = userRep.FindById(1);

            Console.WriteLine(mySearchBook.Id + " " + mySearchBook.Title + " " + mySearchBook.Year);
            Console.WriteLine(myserchUser.Id + " " + myserchUser.Name + " " + myserchUser.Email);
            Console.WriteLine("_________________________");

            var bookForUpdate = bookRep.UpdateYear(2, 1995);
            var userForUpdate = userRep.UpdateName(1, "Аня");

            foreach (var book in bookRep.FindAll())
            {
                Console.WriteLine(book.Id + " " + book.Title + " " + book.Year);
            }

            Console.WriteLine("__________________________");

           
            foreach (var book in bookRep.SearchBookGenreAndYears("Фантастика", 1990, 2000))
            {
                Console.WriteLine(book.Id + " " + book.Title + " " + book.Year);
            }
            Console.WriteLine("__________________________");

            Console.WriteLine("Автор Тургенев. Количество книг: " + bookRep.CountSearchBookAuthor("Тургенев"));

            Console.WriteLine("__________________________");

            Console.WriteLine("Жанр Научная литература. Количество книг: " + bookRep.CountSearchBookGenre("Научная литература"));

            Console.WriteLine("__________________________");

            bool isBook = bookRep.IsBookAuthorTitle("Тютчев", "Азбука5");
            if (isBook) Console.WriteLine("Книга Тютчева с названием Азбука5 в библиотеке присутствует.");
            else Console.WriteLine("Книга Тютчева с названием Азбука5 в библиотеке отсутствует.");

        }
    }
}
