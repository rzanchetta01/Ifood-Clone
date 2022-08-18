using LoginWorker.Infra;
using LoginWorker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWorker.Service
{
    internal class LoginService : ILoginServiceOperations
    {
        private readonly LoginRepository repository;

        public LoginService(LoginRepository repository)
        {
            this.repository = repository;
        }

        public void CreateUserLogin(UserLogin userLogin)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserLoin(UserLogin userLogin)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserLoin(UserLogin userLogin)
        {
            throw new NotImplementedException();
        }

        public void Login(string? email, string? username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
