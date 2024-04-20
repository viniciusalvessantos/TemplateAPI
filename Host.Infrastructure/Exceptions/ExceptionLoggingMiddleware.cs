using Hosted.Exceptions.Abstraction;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using System.Net;

namespace Hosted.Infrastructure.Exceptions {
    public class ExceptionLoggingMiddleware {
        private readonly RequestDelegate _next;
        private const string ContentType = "application/json";

        public ExceptionLoggingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext) {
            try {
                await _next(httpContext);
            } catch (Exception ex) {
                var logLevel = GetLoggerLevel(ex);
                Log.Logger.Write(logLevel, ex, "Exception has been thrown");

                httpContext.Response.ContentType = ContentType;
                httpContext.Response.StatusCode = GetHttpStatusCode(ex);

                var exceptionMessage = FormatErrorMessage(ex);
                await httpContext.Response.WriteAsync(exceptionMessage);
            }
        }

        private string FormatErrorMessage(Exception ex) =>
            ex switch {
                DomainException domainException => JsonConvert.SerializeObject(
                    new ErroMessage(domainException.ExceptionCode, domainException.Message)),
                ValidationException validationException => JsonConvert.SerializeObject(new ValidationErrorMessage(validationException.ExceptionCode, validationException.Message,
                    validationException.ValidationMessages)),
                AppException appException => JsonConvert.SerializeObject(new ErroMessage(appException.ExceptionCode,
                    appException.Message)),
                _ => JsonConvert.SerializeObject(new ErroMessage(-1, ex.Message)),
            };

        private int GetHttpStatusCode(Exception ex)
            => ex switch {
                DomainException _ => (int)HttpStatusCode.BadRequest,
                AppException _ => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };


        private LogEventLevel GetLoggerLevel(Exception ex)
            => ex switch {
                DomainException _ => LogEventLevel.Information,
                AppException _ => LogEventLevel.Information,
                _ => LogEventLevel.Error
            };
    }
}
