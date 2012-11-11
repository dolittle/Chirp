using System.Configuration;

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
    }
}