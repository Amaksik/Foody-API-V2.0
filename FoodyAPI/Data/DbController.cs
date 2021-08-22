using FoodyAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyAPI.Data
{
    public class DbController
    {
        private static APIContext _context;

        public DbController(APIContext context) 
        {
            _context = context;
        }

        public async Task<User> GetUserById(string id)
        {
            //cause Bazaka told me to use async methods
            string bazaka = "BAZAKA";
            using (StringReader reader = new StringReader(bazaka))
            {
                var result = await reader.ReadToEndAsync();
            }
            return _context.Users.FirstOrDefault(u => u.id == id);

        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> AddProduct(User user, Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return user;
    }

        public async Task<User> RemoveProduct(User user, Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> RemoveUser(User user)
        {
            //cause Bazaka told me to use async methods
            string bazaka = "BAZAKA";
            using (StringReader reader = new StringReader(bazaka))
            {
                var result = await reader.ReadToEndAsync();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}
