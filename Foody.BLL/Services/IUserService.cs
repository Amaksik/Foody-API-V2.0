using Foody.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foody.BLL
{
    public interface IUserService
    {
        Task<bool> AddProduct(int user_id, Product prdct);
        Task<bool> Consume(int user_id, double amount);
        void CreateUser(User User);
        Task<IEnumerable<Product>> GetFavourites(User User);
        Task<ICollection<DayIntake>> GetStatistics(string user_id, int days);
        Task<User> GetUser(int user_id);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> RemoveProduct(int user_id, Product prdct);
        Task<bool> RemoveUser(int user_id);
    }
}