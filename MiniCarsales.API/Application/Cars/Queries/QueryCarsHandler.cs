using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MiniCarsales.API.Application.Common.Commands;
using MiniCarsales.API.Application.Common.Queries;
using AutoMapper;
using MiniCarsales.Core.Entities;
using MiniCarsales.Infrastructure.Data;

namespace MiniCarsales.API.Application.Cars.Queries
{
    public class QueryCarsRequest : IQuery<Car>
    {
        public QueryCarsRequest()
        {
        }

        public IEnumerable<Car> Query { get; set; }
    }

    public class QueryCarsHandler : QueryHandler<Car, QueryCarsRequest>
    {
        public QueryCarsHandler(VehicleContext context, IMapper mapper) : base(context, mapper) { }
    }
}