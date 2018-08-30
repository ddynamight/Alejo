using Alejo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejo.Data.Repository
{
    public interface IUserRepository
    {
          void AddUser(AppUser user);
          void DeleteUser(AppUser user);
          AppUser GetUser(string username);
          IEnumerable<AppUser> GetUsers();
          void UpdateUser(AppUser user);
    }
}
