using Rent.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Services
{
    public class Connection //: IDisposable
    {
        public SIPAZEntities _db;
        private DbDataReader _reader;
        protected DbCommand _cmd;
        public Connection()
        {
            _db = new SIPAZEntities();
            this._cmd = _db.Database.Connection.CreateCommand();
        }

        public IList<T> GetList<T>()
        {
            try
            {
                
                this._db.Database.Connection.Open();
                this._cmd.CommandType = CommandType.StoredProcedure;
                this._reader = this._cmd.ExecuteReader();
                IList<T> data = ((IObjectContextAdapter)this._db).ObjectContext.Translate<T>(this._reader).ToList();
                return data;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this._db.Database.Connection.State == ConnectionState.Open)
                {
                    this._db.Database.Connection.Close();
                }
            }

        }

        //public void Dispose()
        //{
        //    // Dispose of unmanaged resources.
        //    Dispose();
        //    // Suppress finalization.
        //    GC.SuppressFinalize(this);
        //}

    }
}
