using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Test.DAL
{
    public class UnitOfWork: IDisposable
    {
        private AppContext context = new AppContext();
        private bool disposed = false;

        public UnitOfWork()
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}