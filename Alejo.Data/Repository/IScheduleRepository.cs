using Alejo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejo.Data.Repository
{
     public interface IScheduleRepository
     {
          void AddSchedule(Schedule schedule);
          IEnumerable<Schedule> GetSchedulesForUser(string username);
     }
}
