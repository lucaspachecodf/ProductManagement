namespace AutoGlass.ProductManagement.Domain.Entities
{
    public class Product : EntityBase<int>
    {   
        public string Description { get; set; }
        public bool Status { get; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCNPJ { get; set; }        
    }
}
