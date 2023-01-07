
//using FluentValidation;
//using Microsoft.AspNetCore.Http;
//using SecretSharing.Domain.Exceptions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace SecretSharing.Api.Middleware
//{
//    internal sealed class ExceptionHandlingMiddleware : IMiddleware
//    {
//        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
//        {
//			try
//			{
//				await next(context);
//			}
//			catch (Exception e)
//			{

//				await HandleExceptionAsync(context, e);
//			}
//        }

//		private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
//		{
//			var statusCode = GetStatusCode(exception);

//			var response = new
//			{
//				title = GetTitle(exception),
//				status = statusCode,
//				detail = exception.Message,
//				errors = GetErrors(exception)
//			};

//			httpContext.Response.ContentType = "application/json";
//			httpContext.Response.StatusCode = statusCode;

//			await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
//		}

//		private static string GetTitle(Exception exception) =>
//			exception switch
//			{
//				DomainException domainExceprion => domainExceprion.Message,
//				_ => "Server Error"
//			};

//		private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
//		{
//			IReadOnlyDictionary<string, string[]> errors = null;
//			if(exception is ValidationException validationException)
//			{
//				errors = validationException.

//            }
//		}

//		private static int GetStatusCode(Exception exception) =>
//			exception switch
//			{
//				BadHttpRequestException => StatusCodes.Status400BadRequest,
//				NotFoundDomainException => StatusCodes.Status404NotFound,
//				ValidationException => StatusCodes.Status422UnprocessableEntity,
//				_ => StatusCodes.Status500InternalServerError
//			};
//    }
//}
