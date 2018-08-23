using Alejo.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejo.Web.Areas.Admin.Controllers
{
     [Authorize(Roles = "Admin"), Area("Admin"), Route("Admin/Schedules/")]
     public class SchedulesController : Controller
     {
          private AppDbContext db;

          public SchedulesController(AppDbContext _db)
          {
               db = _db;
          }

          public async Task<IActionResult> Index()
          {
               return View(await db.Schedules.Include(e => e.AppUser).ToListAsync());
          }
     }
}
