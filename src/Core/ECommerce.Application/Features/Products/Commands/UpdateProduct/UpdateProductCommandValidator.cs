﻿using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Title");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Description");

            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .WithName("Brand identity");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Price");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .WithName("Discount");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any())
                .WithName("Category identity");
        }
    }
}
