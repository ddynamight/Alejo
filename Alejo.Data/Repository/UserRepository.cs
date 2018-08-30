using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alejo.Data.Entities;

namespace Alejo.Data.Repository
{
     public class UserRepository : IUserRepository
     {
          private AppDbContext db;

          public UserRepository(AppDbContext _db)
          {
               db = _db;
          }

          public void AddUser(AppUser user)
          {
               throw new NotImplementedException();
          }

          public void DeleteUser(AppUser user)
          {
               throw new NotImplementedException();
          }

          public AppUser GetUser(string username)
          {
               throw new NotImplementedException();
          }

          public IEnumerable<AppUser> GetUsers()
          {
               throw new NotImplementedException();
          }

          public void UpdateUser(AppUser user)
          {
               throw new NotImplementedException();
          }
     }
}
