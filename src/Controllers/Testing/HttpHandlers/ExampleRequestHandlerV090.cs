using MediatR;
using MinimalApiWithHandlers.Controllers.Testing.Responses;
using MinimalApiWithHandlers.Requests;

namespace MinimalApiWithHandlers.Controllers.Testing.HttpHandlers;

internal record ExampleRequestV090(int Age, string Name) : IHttpRequest;
internal class ExampleRequestHandlerV090 : IRequestHandler<ExampleRequestV090, IResult>
{
    public async Task<IResult> Handle(ExampleRequestV090 request, CancellationToken cancellationToken)
    {
        await Task.Delay(500, cancellationToken);

        var random = new Random();
        var nextInt = random.Next(0, 10);
        if (nextInt % 2 == 0)
        {
            return Results.Problem("Problem occured", statusCode: 500);
        }

        if (nextInt % 3 == 0)
        {
            return Results.ValidationProblem(new Dictionary<string, string[]>()
            {
                { "issue", new [] { "-1"} }
            });
        }
        
        
        return Results.Ok(new ExampleRequestResponse($"Version 0.90; Age: {request.Age}, Name: {request.Name}"));
    }
}
