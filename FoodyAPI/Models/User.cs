using FoodyAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyAPI.Models
{
    public class UsersData
    {
        public List<User> users { get; set; }

    }


    public class User
    {
        [Key]
        public string id { get; set; }
        public double callories { get; set; }

        public virtual List<Product> Favourite {get; set;}
        public virtual List<DayIntake> Statistics { get; set; }

        public void Addproduct(Product p)
        {
            if (Favourite == null)
            {
                Favourite = new List<Product>();
            }
            this.Favourite.Add(p);
        }
        public void RemoveProduct(Product p)
        {
            this.Favourite.Remove(p);
        }

    }
}
