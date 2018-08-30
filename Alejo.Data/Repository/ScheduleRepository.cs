using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alejo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alejo.Data.Repository
{
     public class ScheduleRepository : IScheduleRepository
     {
          private AppDbContext db;

          public ScheduleRepository(AppDbContext _db)
          {
               db = _db;
          }

          public void AddSchedule(Schedule schedule)
          {
               throw new NotImplementedException();
          }

          public IEnumerable<Schedule> GetSchedulesForUser(string username)
          {

               return  db.Schedules.Include(e => e.AppUser).Where(e => e.AppUser.UserName.Equals(username)).ToList();
          }
     }
}
