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
     [Authorize(Roles = "Admin"), Area("Admin"), Route("Admin/Users/")]
     public class UsersController : Controller
     {
          private AppDbContext db;

          public UsersController(AppDbContext _db)
          {
               db = _db;
          }

          public async Task<IActionResult> Index()
          {
               return View(await db.AppUsers.ToListAsync());
          }
     }
}
