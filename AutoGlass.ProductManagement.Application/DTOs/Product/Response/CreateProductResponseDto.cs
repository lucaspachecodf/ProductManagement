using FluentValidation.Results;

namespace AutoGlass.ProductManagement.Application.DTOs.Product.Response
{
    public class CreateProductResponseDto
    {
        public int ProductId { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
