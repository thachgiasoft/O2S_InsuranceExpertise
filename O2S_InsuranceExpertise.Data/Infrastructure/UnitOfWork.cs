﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_InsuranceExpertise.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        //private TeduShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        //public TeduShopDbContext DbContext
        //{
        //    get { return dbContext ?? (dbContext = dbFactory.Init()); }
        //}

        public void Commit()
        {
           // DbContext.SaveChanges();
        }
    }
}
