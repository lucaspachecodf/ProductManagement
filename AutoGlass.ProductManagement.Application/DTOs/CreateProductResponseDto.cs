using FluentValidation.Results;

namespace AutoGlass.ProductManagement.Application.DTOs
{
    public class CreateProductResponseDto
    {
        public int ProductId { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
