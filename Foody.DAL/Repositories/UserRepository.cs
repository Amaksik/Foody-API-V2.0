using Foody.DAL.EF;
using Foody.DAL.Entities;
using Foody.DAL.InnerExceptions;
using Foody.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private APIContext _context;
        public UserRepository(APIContext context)
        {
            _context = context;
        }


        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }
        
        public User Get(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id.ToString());
            return user;

        }

        public IEnumerable<Product> Favourites(int id)
        {
            var user = Get(id);
            return user.Favourite;

        }

        public IEnumerable<DayIntake> Statistics(int id)
        {
            var user = Get(id);
            return user.Statistics;

        }

        public void Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChangesAsync();
        }




        public void Update(User entity, Product product, bool ToAdd)
        {
            if (_context.Set<User>().Find(entity) == null)
            {
                throw new NotFoundException(typeof(User).ToString());
            }
            if (ToAdd)
            {

                entity.Favourite.Add(product);
                _context.SaveChangesAsync();

            }
            else
            {
                entity.RemoveProduct(product);
                 _context.SaveChangesAsync();
            }

        }
        public void Update(User user)
        {
            var id = Convert.ToInt32(user.Id);
            Delete(id);
            Create(user);
        }
        
        public void Delete(int id)
        {
            var user = Get(id);
            _context.Users.Remove(user);
            _context.SaveChangesAsync();
        }
    }
}
