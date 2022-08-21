using MediatR;

namespace MinimalApiWithHandlers.Requests;

public interface IHttpRequest : IRequest<IResult>
{
}