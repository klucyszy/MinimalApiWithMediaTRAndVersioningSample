using Asp.Versioning.Builder;
using MediatR;
using MinimalApiWithHandlers.Requests;

namespace MinimalApiWithHandlers;

public static class ProgramExtensions
{
    // mediating extensions
    public static RouteHandlerBuilder MediateGet<TRequest, TResponse>(
        this RouteGroupBuilder groupBuilder,
        string template)
            where TRequest : IHttpRequest
    {
        return groupBuilder.MapGet(template, async (IMediator mediator,
                [AsParameters] TRequest request) => await mediator.Send(request))
            .Produces<TResponse>();
    }
    
    public static RouteGroupBuilder MediatePost<TRequest>(
        this RouteGroupBuilder groupBuilder,
        string template) where TRequest : IHttpRequest
    {
        groupBuilder.MapPost(template, async (IMediator mediator,
            [AsParameters] TRequest request) => await mediator.Send(request));
        return groupBuilder;
    }
    
    public static RouteGroupBuilder MediatePut<TRequest>(
        this RouteGroupBuilder groupBuilder,
        string template) where TRequest : IHttpRequest
    {
        groupBuilder.MapPut(template, async (IMediator mediator,
            [AsParameters] TRequest request) => await mediator.Send(request));
        return groupBuilder;
    }
    
    public static RouteGroupBuilder MediatePatch<TRequest>(
        this RouteGroupBuilder groupBuilder,
        string template) where TRequest : IHttpRequest
    {
        groupBuilder.MapPatch(template, async (IMediator mediator,
            [AsParameters] TRequest request) => await mediator.Send(request));
        return groupBuilder;
    }
    
    public static RouteGroupBuilder MediateDelete<TRequest>(
        this RouteGroupBuilder groupBuilder,
        string template) where TRequest : IHttpRequest
    {
        groupBuilder.MapDelete(template, async (IMediator mediator,
            [AsParameters] TRequest request) => await mediator.Send(request));
        return groupBuilder;
    }
}