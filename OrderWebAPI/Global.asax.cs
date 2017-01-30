using OrderWebAPI.ExceptionTracing;
using log4net;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace OrderWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());
        }

        protected void Application_Error()
        {
            var error = Server.GetLastError();
            Log4Net.Error(string.Format("Unhandled exception thrown in {0}", error));
        }
    }
}