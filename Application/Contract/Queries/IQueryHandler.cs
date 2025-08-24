using MediatR;

namespace Backend.Application.Contract.Contract.Queries
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}