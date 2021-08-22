using Foody.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foody.BLL.DTO
{
    public class NutritionixResponse
    {
        public List<Food> foods { get; set; } 
    }

    public class Food
    {
        public string food_name { get; set; }
        public double nf_calories { get; set; }
        public double nf_total_fat { get; set; }
        public double nf_total_carbohydrate { get; set; }
        public double nf_protein { get; set; }

    }
}
