﻿using Foody.DAL.EF;
using Foody.DAL.Entities;
using Foody.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private IUserRepository userRepository;
        //private IProductRepository userRepository;

        //
        public UnitOfWork(IUserRepository _userRepository)
       {
            userRepository = _userRepository;
       }
        //
        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    throw new DllNotFoundException();
                return userRepository;
            }
        }

        public void Save()
        {
            userRepository.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userRepository.Dispose();
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

