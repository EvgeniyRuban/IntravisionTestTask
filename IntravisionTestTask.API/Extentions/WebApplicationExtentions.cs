using IntravisionTestTask.Domain.Exceptinos;
using Microsoft.AspNetCore.Diagnostics;

namespace IntravisionTestTask.API.Extentions
{
    public static class WebApplicationExtentions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILogger logger)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            EntityNotFoundException => StatusCodes.Status404NotFound,
                            EntityAlreadyExistsException => StatusCodes.Status400BadRequest,
                            InvalidOperationException => StatusCodes.Status400BadRequest,
                            ProductAlreadyPlacedException => StatusCodes.Status400BadRequest,
                            ProductSlotHasNoSpaceException => StatusCodes.Status400BadRequest,
                            ProductSlotLessCapacityException => StatusCodes.Status400BadRequest,
                            ProductSlotTypeDifferentException => StatusCodes.Status400BadRequest,
                            ProductMachineHasNoSpaceException => StatusCodes.Status400BadRequest,
                            ProductSlotAlreadyPlacedException => StatusCodes.Status400BadRequest,
                            ProductSlotProductTitleException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        logger.LogError("Request Method: {method}; Path: {path}; Query: {query}", context.Request.Method, context.Request.Path, context.Request.QueryString.Value);
                        await context.Response.WriteAsJsonAsync(
                            new
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message
                            });
                    }
                });
            });
        }
    }
}
