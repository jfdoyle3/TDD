using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticallyBoundLibrary
{
    public class BusinessService
    {
        private DataStoreProvider _dataStoreProvider;
        private LoggingProvider _loggingProvider;
        private WebServiceProvider _webServiceProvider;

        public BusinessService(DataStoreProvider dataStoreProvider, LoggingProvider loggingProvider, WebServiceProvider webServiceProvider)
        {
            _dataStoreProvider = dataStoreProvider;
            _loggingProvider = loggingProvider;
            _webServiceProvider = webServiceProvider;
        }
    }

    public class DataStoreProvider
    {

    }

    public class LoggingProvider
    {

    }

    public class WebServiceProvider
    {

    }
}