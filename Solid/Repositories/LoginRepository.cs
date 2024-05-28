using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _context;
        public LoginRepository(DataContext context)
        {
            _context = context;
        }
        public Login LogIn(Login l)
        {
            var templ = _context.Managers.ToList().Find(x => x.UserName == l.UserName && x.Password == l.Password);
            return templ;

        }
    }
}
