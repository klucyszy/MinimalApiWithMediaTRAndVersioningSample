using Asp.Versioning.Builder;
using MinimalApiWithHandlers.Controllers.Testing.HttpHandlers;
using MinimalApiWithHandlers.Controllers.Testing.Responses;

namespace MinimalApiWithHandlers.Controllers.Testing;

public static class TestingExtensions
{
    public static WebApplication AddTestingControllerWithActions(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        var controllerBuilder = app.MapGroup("/testing")
            .WithTags("Testing Controller")
            .WithDescription("This is a Testing Controller description");
        
        controllerBuilder
            .MediateGet<ExampleRequestV090, ExampleRequestResponse>("/example/{name}")
            .ProducesValidationProblem()
            .ProducesProblem(500)
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(WebApiVersionsExtensions.ApiVersion090);
        
        controllerBuilder
            .MediateGet<ExampleRequestV100, ExampleRequestResponse>("/example/{name}")
            .ProducesValidationProblem()
            .ProducesProblem(500)
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(WebApiVersionsExtensions.ApiVersion100);
        
        return app;
    }
}