using Rent.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Services
{
    public class Connection //: IDisposable
    {
        public SIPAZEntities _db;
        private DbDataReader _reader;
        protected DbCommand _cmd;
        protected DbParameterCollection _parameter;
        public Connection()
        {
            this._db = new SIPAZEntities();
            this._cmd = _db.Database.Connection.CreateCommand();
        }

        public IList<T> GetList<T>()
        {
            try
            {
                if (this._db.Database.Connection.State == ConnectionState.Closed)
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
                    this._db.Database.Connection.Close();
            }

        }

        public T GetProperty<T>()
        {
            try
            {
                if (this._db.Database.Connection.State == ConnectionState.Closed)
                    this._db.Database.Connection.Open();
                this._cmd.CommandType = CommandType.StoredProcedure;
                this._reader = this._cmd.ExecuteReader();
                T data = ((IObjectContextAdapter)this._db).ObjectContext.Translate<T>(this._reader).FirstOrDefault();
                return data;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this._db.Database.Connection.State == ConnectionState.Open)
                    this._db.Database.Connection.Close();
            }

        }

        //public static List<T> ToListof<T>(this DataTable dt)
        //{
        //    const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
        //    var columnNames = dt.Columns.Cast<DataColumn>()
        //        .Select(c => c.ColumnName)
        //        .ToList();
        //    var objectProperties = typeof(T).GetProperties(flags);
        //    var targetList = dt.AsEnumerable().Select(dataRow =>
        //    {
        //        var instanceOfT = Activator.CreateInstance<T>();

        //        foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
        //        {
        //            properties.SetValue(instanceOfT, dataRow[properties.Name], null);
        //        }
        //        return instanceOfT;
        //    }).ToList();

        //    return targetList;
        //}

        //public void Dispose()
        //{
        //    // Dispose of unmanaged resources.
        //    Dispose();
        //    // Suppress finalization.
        //    GC.SuppressFinalize(this);
        //}

    }
}
