using System;
using System.Data.SqlClient;

namespace DemoEF
{
    public class StoreConnectionAccessor : IDisposable
    {
        private readonly SqlConnection _sqlConnection;
        private readonly StoreContext _context;

        public StoreConnectionAccessor()
        {
            _context = new StoreContext();
            _sqlConnection = _context.Database.Connection as SqlConnection;
        }

        public SqlConnection Connection
        {
            get
            {
                return _sqlConnection;
            }
        }

        public void Dispose()
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
            _context.Dispose();
        }
    }
}
