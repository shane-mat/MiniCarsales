using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MiniCarsales.Core.Interfaces;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace MiniCarsales.API.Application.Common.Commands
{
    public class CreateCommandHandler<TEntity, TCommand> : IRequestHandler<TCommand, Unit>
        where TEntity : class, IEntity, new()
        where TCommand : class, ICreateCommand<TEntity>, new()
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        protected CreateCommandHandler(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TCommand, TEntity>(request);

            _context.Set<TEntity>().Add(entity);

            var success = await _context.SaveChangesAsync(cancellationToken) > 0;

            if(success)
            {
                return Unit.Value;
            }
            throw new Exception("Error saving");
        }
    }
}