using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _LoginRepository;

        public LoginService(ILoginRepository LoginRepository)
        {
            _LoginRepository = LoginRepository;
        }
        public Login Login(Login l)
        {
            return _LoginRepository.LogIn(l);
        }

    }
}
