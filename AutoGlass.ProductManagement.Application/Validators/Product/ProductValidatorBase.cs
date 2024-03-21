using AutoGlass.ProductManagement.Application.DTOs.Product;
using FluentValidation;

namespace AutoGlass.ProductManagement.Application.Validators.Product
{
    public abstract class ProductValidatorBase<T> : AbstractValidator<T> where T : ProductDtoBase
    {
        protected ProductValidatorBase()
        {
            RuleFor(dto => dto.Description)
                .NotEmpty()
                .WithMessage("O campo Descrição é obrigatório.")
                .MaximumLength(200)
                .WithMessage("O campo Descrição deve ter no máximo 200 caracteres.");

            RuleFor(dto => dto.ManufacturingDate)
                 .Must((dto, manufacturingDate) =>
                 {
                     return manufacturingDate.Date < dto.ExpirationDate.Date;
                 })
                 .WithMessage("A Data de Fabricação não pode ser maior ou igual à Data de Validade.");
        }
    }
}
