using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm.Models
{
    public  interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel user);
        void Edit(UserModel user);
        void Remove(int id);
        UserModel? GetById(int id);
        UserModel? GetByUserName(string? userName);
        IEnumerable<UserModel> GetByAll();
    }
}
