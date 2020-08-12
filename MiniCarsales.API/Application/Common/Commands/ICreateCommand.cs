
using MediatR;

namespace MiniCarsales.API.Application.Common.Commands
{
    public interface ICreateCommand<out TEntity> : IRequest<Unit> where TEntity : class, new() { }
}