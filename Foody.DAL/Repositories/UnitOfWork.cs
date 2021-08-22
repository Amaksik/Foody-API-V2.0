using Foody.DAL.EF;
using Foody.DAL.Entities;
using Foody.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Repositories
{
    public class UnitOfWork
    {

        private APIContext dbcontext;
        private UserRepository userRepository;

       //
       public UnitOfWork()
        {
            dbcontext = new APIContext();
        }
        //
        public UnitOfWork(string connectionString)
        {
            dbcontext = new APIContext();
        }
        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(dbcontext);
                return userRepository;
            }
        }

        public void Save()
        {
            dbcontext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbcontext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}

