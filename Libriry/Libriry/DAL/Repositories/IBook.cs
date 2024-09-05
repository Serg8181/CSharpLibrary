using Library.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    internal interface IBook
    {
        //найти по ID
        Book FindById(int id);
        //найти все объекты
        IEnumerable<Book> FindAll();
        //добавление в базу данных
        int Create(Book book);
        //удаление из базы данных
        int Delete(Book book);
        //обновление года выпуска книги по ID
        bool UpdateYear(int id, int year);
        //Получать список книг определенного жанра и вышедших между определенными годами
        public List<Book> SearchBookGenreAndYears(string genre, int startYear, int endYear);
        //Получать количество книг определенного автора в библиотеке
        public int CountSearchBookAuthor(string author);
        //Получать количество книг определенного жанра в библиотеке
        public int CountSearchBookGenre(string genre);
        //получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
        public bool IsBookAuthorTitle(string author, string title);
        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя
        //Получать количество книг на руках у пользователя
        //Получение последней вышедшей книг
        Book LatestBookPublished();
        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        List<Book> GetSortTitleBooks();
        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        List<Book> GetSortYearBooks();
    }
}
