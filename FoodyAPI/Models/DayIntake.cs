using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyAPI.Models
{
    public class DayIntake
    {
        [Key]
        public int id { get; set; }
        private static double dayCalories { get; set; }
        public DateTime date { get; set; }
        public virtual User user { get; set; }

    }
}
