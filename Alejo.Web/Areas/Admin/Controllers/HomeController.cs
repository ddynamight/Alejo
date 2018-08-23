using Alejo.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejo.Web.Areas.Admin.Controllers
{
     [Authorize(Roles = "Admin"), Area("Admin"), Route("Admin/")]
     public class HomeController : Controller
     {
          private AppDbContext db;

          public HomeController(AppDbContext _db)
          {
               db = _db;
          }

          public IActionResult Index()
          {
               return View();
          }
     }
}
