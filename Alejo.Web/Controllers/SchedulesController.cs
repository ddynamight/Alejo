using Alejo.Data.Entities;
using Alejo.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejo.Web.Controllers
{
     [Authorize]
     public class SchedulesController : Controller
     {
          private IScheduleRepository scheduleRepository;
          private IUserRepository userRepository;
          private AppDbContext db;

          public SchedulesController(IUserRepository _userRepository, IScheduleRepository _scheduleRepository, AppDbContext _db)
          {
               scheduleRepository = _scheduleRepository;
               userRepository = _userRepository;
               db = _db;
          }

          public async Task<IActionResult> Index()
          {
               //return View(await db.Schedules.Where(e => e.AppUser.UserName.Equals(User.Identity.Name)).ToListAsync());

               var schedules = scheduleRepository.GetSchedulesForUser(User.Identity.Name);

               return View(schedules);
          }

          [HttpGet]
          public async Task<IActionResult> Delete(Guid id)
          {
               return View(await db.Schedules.SingleAsync(e => e.Id.Equals(id)));
          }

          [HttpPost]
          public async Task<IActionResult> Delete(Guid id, Schedule schedule)
          {

               if (ModelState.IsValid)
               {
                    db.Schedules.Remove(schedule);
                    db.Entry(schedule).State = EntityState.Deleted;
                    await db.SaveChangesAsync();

                    return View();
               }

               return View(schedule);
          }
     }
}
