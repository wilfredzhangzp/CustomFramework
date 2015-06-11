using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace WrappedDapper
{
    public class ConnectionFactory
    {
        private static object obj = new object();

        private static ConnectionFactory _instance;
        public static ConnectionFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (obj)
                    {
                        if (_instance == null)
                        {
                            _instance= new ConnectionFactory();
                        }
                    }
                }
                return _instance;
            }
        }

        public IDbConnection GetConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
