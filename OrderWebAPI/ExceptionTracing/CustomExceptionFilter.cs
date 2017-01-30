using log4net;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace OrderWebAPI.ExceptionTracing
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }
            Log4Net.Error(String.Format("Unhandled exception thrown in {0} for request {1}: {2}",
               actionExecutedContext.Request.Method, actionExecutedContext.Request.RequestUri, exceptionMessage));

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
            actionExecutedContext.Response = response;
        }
    }
}