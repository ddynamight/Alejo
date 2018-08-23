using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejo.Data.Entities
{
     public class Schedule
     {
          public Guid Id { get; set; }
          public string Name { get; set; }
          public string AccessCode { get; set; }
          public string Email { get; set; }
          public string Phone { get; set; }
          public string Address { get; set; }
          public DateTime Date { get; set; }

          // Details about the Schedule/Meeting
          public string Purpose { get; set; }
          public string FromWhere { get; set; }
          public string ToWhom { get; set; }
          public string CompanyName { get; set; }
          public string EventName { get; set; }
          public string Details { get; set; }


          // One to Many Schedule Relationship
          public string AppUserId { get; set; }
          public virtual AppUser AppUser { get; set; }
     }
}
