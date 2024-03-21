namespace AutoGlass.ProductManagement.Application.DTOs.Product
{
    public class ProductDtoBase
    {
        public string? Description { get; set; }
        public bool Status { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? SupplierCode { get; set; }
        public string? SupplierDescription { get; set; }
        public string? SupplierCNPJ { get; set; }
    }
}
