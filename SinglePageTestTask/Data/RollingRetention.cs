using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePageTestTask.Data
{
    public class RollingRetention
    {
        [Key]
        public int DayOfWeek { get; set; }
        public decimal Value { get; set; }
    }
}
