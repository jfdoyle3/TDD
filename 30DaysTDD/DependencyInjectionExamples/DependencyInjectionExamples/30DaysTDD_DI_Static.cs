using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticallyBoundLibrary
{
    public class BusinessService
    {
        private SqlDataStoreProvider _dataStoreProvider = new SqlDataStoreProvider();
        private DbLoggingProvider _loggingProvider = new DbLoggingProvider();
        private ProdWebServiceProvider _webServiceProvider = new ProdWebServiceProvider();
    }

    public class SqlDataStoreProvider
    {

    }

    public class DbLoggingProvider
    {

    }

    public class ProdWebServiceProvider
    {

    }
}