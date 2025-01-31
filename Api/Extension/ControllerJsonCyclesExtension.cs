using System.Text.Json.Serialization;

namespace Api.Extension;

public static class ControllerJsonCyclesExtension
{
    public static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(i =>
        i.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        return services;
    }
}
