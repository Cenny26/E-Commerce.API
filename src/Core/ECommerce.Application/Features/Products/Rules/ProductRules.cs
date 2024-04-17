﻿using ECommerce.Application.Bases;
using ECommerce.Application.Features.Products.Exceptions;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
        {
            if (products.Any(x => x.Title == requestTitle))
                throw new ProductTitleMustNotBeSameException();

            return Task.CompletedTask;
        }

        public Task ProductMustBeExistsWhenDeleting(Product product, int id)
        {
            if (product is null)
                throw new ProductMustBeExistsWhenDeletingException(id);

            return Task.CompletedTask;
        }
    }
}
