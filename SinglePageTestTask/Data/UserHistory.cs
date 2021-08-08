using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePageTestTask.Data
{
    public class UserHistory
    {
        [Key]
        public int UserId { get; set; }
        public int Days { get; set; }
    }
}
