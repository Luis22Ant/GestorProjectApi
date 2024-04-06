using Microsoft.AspNetCore.Mvc.Filters;
using Gestor.Exception;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Gestor.Communication.Response;

namespace GestorApi.Filter
{
    public class FilterException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = context.Exception is GestorException;

            if (result)
            {
                ExceptionProject(context);
            }
            else
            {
                UnknownError(context);
            }
        }
        private void ExceptionProject(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new NotFoundObjectResult(new ResponseException(context.Exception.Message));
            }
            else if (context.Exception is ErrorBadRequestException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseException(context.Exception.Message));
            }
            else if (context.Exception is ConflictException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                context.Result = new ConflictObjectResult(new ResponseException(context.Exception.Message));
            }
        }
        private void UnknownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseException("Unknown Error"));
        }
    }


}
