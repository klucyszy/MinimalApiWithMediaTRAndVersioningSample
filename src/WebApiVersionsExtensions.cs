using Asp.Versioning;
using Asp.Versioning.Builder;

namespace MinimalApiWithHandlers;

public static class WebApiVersionsExtensions
{
    public static readonly ApiVersion ApiVersion090 = new (0.9);
    public static readonly ApiVersion ApiVersion100 = new(1.0);
    
    public static ApiVersionSet BuildApiVersionSet(this WebApplication app)
    {
        return app.NewApiVersionSet()
            .HasApiVersion(ApiVersion090)
            .HasApiVersion(ApiVersion100)
            .ReportApiVersions()
            .Build();
    }
}