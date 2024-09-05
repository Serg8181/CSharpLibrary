using Library.BLL.Models;
using Library.DAL.Repositories;

public class Program
{
    static void Main(string[] args)
    {
        using (var db = new Library.DAL.Repositories.AppContext())
        {


            var book1 = new Book { Title = "Азбука1", Year = 1980, Author ="Тютчев", Genre = "Научная литература"};
            var book2 = new Book { Title = "Букварь2", Year = 1990, Author = "Тургенев", Genre = "Фантастика" };
            var book3 = new Book { Title = "Азбука3", Year = 1999, Author = "Толстой", Genre = "Художественная литература" };
            var book4 = new Book { Title = "Математика4", Year = 1965, Author = "Тютчев", Genre = "Научная литература" };
            var book5 = new Book { Title = "Словарь5", Year = 1991, Author = "Тургенев", Genre = "Фантастика" };
            var book6 = new Book { Title = "Термодинамика6", Year = 2005, Author = "Тургенев", Genre = "Фантастика" };

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

            Console.WriteLine("_________________________");
            Console.WriteLine("Книги в библиотеке: ");

            foreach (var book in bookRep.FindAll())
            {
                Console.WriteLine(book.Id + " " + book.Title + " " + book.Year);
            }
            Console.WriteLine("Книги в алфавитном порядке: ");
            foreach (var book in bookRep.GetSortTitleBooks())
            {
                Console.WriteLine(book.Id + " " + book.Title + " " + book.Year);
            }
            Console.WriteLine("_________________________");
            Console.WriteLine("Книги в порядке убывания года публикации: ");
            foreach (var book in bookRep.GetSortYearBooks())
            {
                Console.WriteLine(book.Id + " " + book.Title + " " + book.Year);
            }
            Console.WriteLine("_________________________");
            Console.WriteLine("Последняя опубликованная книга: ");

            var bookLast = bookRep.LatestBookPublished();
            Console.WriteLine(bookLast.Title + " " + bookLast.Author + " " + bookLast.Year + " год.");

            Console.WriteLine();
            Console.WriteLine("Пользователи библиотеки: ");

            foreach (var user in userRep.FindAll())
            {
                Console.WriteLine(user.Id + " " + user.Name + " " + user.Email);
            }
            Console.WriteLine("_________________________");
            Console.WriteLine($"Выданы книги {book2.Title} и {book1.Title} ") ;
            userRep.UserTakeBook(user1.Id, book2);
            userRep.UserTakeBook(user2.Id, book1);


            Console.WriteLine("_________________________");
            Console.WriteLine($"Выдана ли книга {book2.Title} и какому пользователю?");

            if(userRep.IsBookUserHand(user1.Id , book2))
            {
                Console.WriteLine($"Книга {book2.Title} выдана. Находится у {user1.Name} ") ;
            }
            Console.WriteLine("_________________________");
            Console.WriteLine("Количество книг на руках у пользователей:");
            foreach (var user in userRep.FindAll())
            {
                Console.WriteLine($"{user.Name} - {userRep.CountUserBook(user.Id)} книг");
            }



            //bookRep.Delete(book1);
            //userRep.Delete(user1);

            Console.WriteLine("Поиск книг по ID: ");
            var mySearchBook = bookRep.FindById(2);
            Console.WriteLine(mySearchBook.Id + " " + mySearchBook.Title + " " + mySearchBook.Year);
            Console.WriteLine("_________________________");
            Console.WriteLine("Поиск пользователя по ID: ");
            var myserchUser = userRep.FindById(1);
            Console.WriteLine(myserchUser.Id + " " + myserchUser.Name + " " + myserchUser.Email);
            Console.WriteLine("_________________________");
            Console.WriteLine("Обновление года выпуска книги: ");
            if(bookRep.UpdateYear(2, 1995))
            {
                Console.WriteLine("Обновление года выпуска книги с ID 2 успешно.");
            }
            else
            {
                Console.WriteLine("Книги с ID 2 не существует.");
            }
            Console.WriteLine("Обновление имени пользователя: ");

            if(userRep.UpdateName(1, "Аня"))
            {
                Console.WriteLine("Обновление имени пользователя с ID 1 успешно.");
            }
            else
            {
                Console.WriteLine("Пользователя с ID 1 не существует.");
            }
            Console.WriteLine("Найти все книги:");
            foreach (var book in bookRep.FindAll())
            {
                Console.WriteLine(book.Id + " " + book.Title + " " + book.Year);
            }
            Console.WriteLine("__________________________");

            Console.WriteLine("Найти книги по жанру между определенными годами: ");
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
