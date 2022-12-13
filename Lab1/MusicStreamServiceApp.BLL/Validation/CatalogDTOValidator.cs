﻿using System;
using FluentValidation;
using MusicStreamServiceApp.BLL.DTOs;

namespace MusicStreamServiceApp.BLL.Validation
{
    public class CatalogDTOValidator : AbstractValidator<CatalogDTO>
    {
        public CatalogDTOValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(e => e.Author)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(e => e.Year)
                .NotNull()
                .LessThanOrEqualTo(DateTime.Now.Year)
                .GreaterThanOrEqualTo(1970);
        }
    }
}
