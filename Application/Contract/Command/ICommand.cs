using MediatR;

namespace Backend.Application.Contract.Command
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
