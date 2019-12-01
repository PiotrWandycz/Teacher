﻿using MediatR;

namespace Teacher.Website.Feature.Category.CreateUpdate
{
    public class Command : IRequest<Unit>
    {
        public Model.CategoryModel Category { get; set; }
    }
}