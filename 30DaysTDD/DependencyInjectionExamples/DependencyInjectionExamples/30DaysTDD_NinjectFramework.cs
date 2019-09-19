using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;

namespace DependencyInjectionExamples
{
    class _30DsysTDD_Ninject
    {
        public class DomainModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IDataStoreProvider>().To<DataStoreProvider>();
                Bind<ILoggingProvider>().To<LoggingProvider>();
                Bind<IWebServiceProvider>().To<WebServiceProvider>();
            }
        }
         public class BusinessServiceConsumer
        {
            private BusinessService _businessService;

            public BusinessServiceConsumer()
            {
                var kernel = new StandardKernel(new DomainModule());

                _businessService = kernel.Get<BusinessService>();


            }

        }
        public class DataStoreProvider : IDataStoreProvider
        {

          private ILoggingProvider _loggingProvider;

 

          public DataStoreProvider(ILoggingProvider loggingProvider)
          {

              this._loggingProvider = loggingProvider;

          }

        }        
    }
}
