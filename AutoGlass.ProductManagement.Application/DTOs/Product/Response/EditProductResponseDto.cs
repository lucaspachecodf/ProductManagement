using FluentValidation.Results;

namespace AutoGlass.ProductManagement.Application.DTOs.Product.Response
{
    public class EditProductResponseDto
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
