using BirthdayAPI.Core.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BirthdayAPI.Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCodeBasedOnException(exception);
            var response = new
            {
                error = exception.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        
        private static int GetStatusCodeBasedOnException(Exception exception)
        {
            if (exception is BadRequestException)
                return StatusCodes.Status400BadRequest;
            else if (exception is NotFoundException)
                return StatusCodes.Status404NotFound;
            else
                return StatusCodes.Status500InternalServerError;
        }
    }

    
}
