namespace AutoGlass.ProductManagement.Application.DTOs.Product
{
    public class ProductFilterDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? SupplierCode { get; set; }        
        public string? SupplierCNPJ { get; set; }
    }
}
