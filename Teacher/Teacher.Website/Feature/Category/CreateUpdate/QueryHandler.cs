﻿using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Category.CreateUpdate
{
    internal class QueryHandler : IRequestHandler<Query, Model>
    {
        private readonly IRepository _repository;

        public QueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Model> Handle(Query query, CancellationToken cancellationToken)
        {
            var model = new Model();
            if (!query.CategoryId.HasValue)
                return model;
            model.Category = await _repository.GetCategoryAsync(query.CategoryId.Value); 
            return model;
        }

    }
}