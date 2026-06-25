namespace Domain;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    
    ICollection<Product> _products = new List<Product>();
}