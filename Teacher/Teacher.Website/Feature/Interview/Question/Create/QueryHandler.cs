using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Teacher.Website.Feature.Tests")]
namespace Teacher.Website.Feature.Interview.Question.Create
{
    internal class QueryHandler : IRequestHandler<Query, ViewModel>
    {
        private readonly IRepository _repository;

        public QueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ViewModel> Handle(Query query, CancellationToken cancellationToken)
        {
            var model = new ViewModel();
            model.Categories = await _repository.GetCategoriesAsync().ContinueWith(x => MapCategories(x.Result));
            return model;
        }

        private List<SelectListItem> MapCategories(IEnumerable<ViewModel.CategoryReadModel> categories)
        {
            return categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
    }
}