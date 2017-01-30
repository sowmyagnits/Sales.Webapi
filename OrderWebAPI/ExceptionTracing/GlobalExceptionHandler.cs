using System.Net;

namespace OrderWebAPI.ExceptionTracing
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void HandleCore(System.Web.Http.ExceptionHandling.ExceptionHandlerContext context)
        {
            context.Result = new GlobalException()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = string.Format("Internal exception has occurred: {0}", context.Exception.Message),
                Request = context.Request
            };
        }
    }
}