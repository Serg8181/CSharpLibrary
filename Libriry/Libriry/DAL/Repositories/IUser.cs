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
        int UpdateName(int id , string name);
       
    }
}
