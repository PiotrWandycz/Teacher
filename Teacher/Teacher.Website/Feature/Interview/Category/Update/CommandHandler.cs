﻿using MediatR;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Interview.Category.Update
{
    internal class CommandHandler : IRequestHandler<Command>
    {
        private readonly IRepository _repository;

        public CommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            await _repository.UpdateCategoryAsync(command.Category.Id, command.Category.Name);
            return Unit.Value;
        }
    }
}