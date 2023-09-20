using VKFW1.Api.Middlewares;

namespace VKFW1.Api.Extensions;

public static class ErrorHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}