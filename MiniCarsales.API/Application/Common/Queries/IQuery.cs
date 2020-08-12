
using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace MiniCarsales.API.Application.Common.Queries
{
    public interface IQuery<TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : class, new()
    {
        IEnumerable<TEntity> Query { get; set; }
    }
}