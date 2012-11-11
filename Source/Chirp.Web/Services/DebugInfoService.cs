using System.Configuration;
using System;

namespace Chirp.Web.Services
{
    public class DebugInfoService
    {
        public object GetConfigurationData()
        {
            return new
            {
                Database = ConfigurationManager.AppSettings["Database"]
            };
        }

        public object TestRavenDBConnection()
        {
            try {
                var store = new Raven.Client.Document.DocumentStore
                {
                    Url = ConfigurationManager.AppSettings["Database"]
                };
                store.Initialize();

                var session = store.OpenSession();
                session.Store(new { Debugging = "This is a debug message" });
            } catch( Exception ex )  {
                return new
                {
                    Exception = ex.GetType().FullName,
                    Message = ex.Message
                };
            }

            return "Success";
        }
    }
}