using APIpizza.Middlewares;
namespace APIpizza.Extensions{
public static class ActionLogMiddleWaresExtensions
{
    public static IApplicationBuilder UseActionLog(this IApplicationBuilder builder)
 {
    return builder.UseMiddleware<ActionLogMiddleWare>();
 }
}
}