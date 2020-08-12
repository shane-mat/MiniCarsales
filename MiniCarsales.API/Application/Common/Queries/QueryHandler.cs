using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MiniCarsales.API.Application.Common.Exceptions;
using AutoMapper;
using MiniCarsales.Core.Interfaces;
using MiniCarsales.Infrastructure.Data;
using MediatR;

namespace MiniCarsales.API.Application.Common.Queries
{
    public abstract class QueryHandler<TEntity, TQuery> : IRequestHandler<TQuery, IEnumerable<TEntity>>
        where TEntity : class, IEntity, new()
        where TQuery : class, IQuery<TEntity>, new()
    {
        protected readonly VehicleContext _context;
        private readonly IMapper _mapper;

        protected QueryHandler(VehicleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IEnumerable<TEntity>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var entites = _context.Set<TEntity>().AsEnumerable();
            if(entites == null)
            {
                throw new CustomException(HttpStatusCode.NotFound, new {entites = "No Vehicles Found"});
            }

            return Task.FromResult(entites);
        }
    }
}