using System;
using System.Net;
using System.Threading.Tasks;
using BizCover.Api.Cars.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json;

namespace BizCover.Api.Cars.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadHttpRequestException ex)
            {

            }
            catch (Exception ex)
            {
                await HandleInternalExceptionAsync(context, ex);
            }
        }

        private static Task HandleInternalExceptionAsync(HttpContext context, Exception ex)
        {
            var error = new ErrorMessageResponse
            {
                Error = ex.Message,
                Status = HttpStatusCode.InternalServerError
            };

            var result = JsonConvert.SerializeObject(error);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) error.Status;
            return context.Response.WriteAsync(result);
        }
    }
}