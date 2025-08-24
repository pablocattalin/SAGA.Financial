using MediatR;

namespace Backend.Application.Contract.Contract.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}