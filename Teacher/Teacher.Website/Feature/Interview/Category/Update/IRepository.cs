﻿using System.Threading.Tasks;
using Teacher.Website.Infrastructure;

namespace Teacher.Website.Feature.Interview.Category.Update
{
    public interface IRepository : IRepositoryMarker
    {
        Task<ViewModel.CategoryInputModel> GetCategoryAsync(int id);
        Task UpdateCategoryAsync(int id, string name);
    }
}