using AutoGlass.ProductManagement.Application.DTOs;
using FluentValidation;

namespace AutoGlass.ProductManagement.Application.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(dto => dto.Description)
                .NotEmpty()
                .WithMessage("O campo Descrição é obrigatório.")
                .MaximumLength(200)
                .WithMessage("O campo Descrição deve ter no máximo 200 caracteres.");
        }
    }
}
