using Foody.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User Get(int id);

        IEnumerable<Product> Favourites(int id);
        IEnumerable<DayIntake> Statistics(int id);

        void Create(User item);
        void Update(User item);
        void Update(User item, Product product, bool ToAdd);

        void Delete(int id);


    }
}
