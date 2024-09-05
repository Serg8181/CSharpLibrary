using Library.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    internal interface IUser
    {
        //найти по ID
        User FindById(int id);
        //найти все объекты
        IEnumerable<User> FindAll();
        //добавление в базу данных
        int Create(User user);
        //удаление из базы данных
        int Delete(User user);
        //обновление имени пользователя по ID
        bool UpdateName(int id , string name);
        //взять книгу в библиотеке
        void UserTakeBook(int id , Book book);
        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя
         bool IsBookUserHand(int id , Book book);
        //Получать количество книг на руках у пользователя
        public int CountUserBook(int id);
        
        
    }
}
