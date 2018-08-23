using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejo.Data.Entities
{
     public class AppUser : IdentityUser
     {
          public AppUser()
          {
               Schedules = new HashSet<Schedule>();
          }

          public string Name { get; set; }

          // One AppUser to Many Relationship
          public virtual ICollection<Schedule> Schedules { get; set; }
     }
}
