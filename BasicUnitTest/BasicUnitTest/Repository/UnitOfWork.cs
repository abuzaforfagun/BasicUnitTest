using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicUnitTest.Repository
{
    public class UnitOfWork
    {
        private DbContext applicationDbcontext;

        public UnitOfWork(DbContext context)
        {
            applicationDbcontext = context;
        }

        public void Done()
        {
            applicationDbcontext.SaveChanges();
        }
    }
}
