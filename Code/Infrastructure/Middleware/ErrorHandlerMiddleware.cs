using Core.Exceptions;
using Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Middleware
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public ErrorHandlerMiddleware() { }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new APIResponse<string>() { Succeded = false, Message = error?.Message };

                switch (error)
                {
                    case ApiException e:
                        // custom application error
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case ValidateException e:
                        // custom application error
                        response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                        responseModel.Errors = e.ErrorsDictionary;
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    case EntityNotFoundException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    case EntityNotEnabledException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status423Locked;
                        break;

                    case EntityDuplicatedException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case EntityAlreadyExistException e:
                        // not found error
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                await response.WriteAsync(JsonConvert.SerializeObject(responseModel, new JsonSerializerSettings()
                {
                    Culture = System.Globalization.CultureInfo.CurrentCulture,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    FloatFormatHandling = FloatFormatHandling.DefaultValue,
                    FloatParseHandling = FloatParseHandling.Decimal,
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
            }
        }
    }
}
