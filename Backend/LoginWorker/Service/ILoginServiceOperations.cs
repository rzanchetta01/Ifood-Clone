using LoginWorker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWorker.Service
{
    internal interface ILoginServiceOperations
    {
        void Login(string? email, string? username, string password);
        void CreateUserLogin(UserLogin userLogin);
        void DeleteUserLoin(UserLogin userLogin);
    }
}
