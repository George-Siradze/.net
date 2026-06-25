using Domain;

namespace Services;

public interface IInnerServices
{
    IEnumerable<Product> GetAllPrdocucts();
    IEnumerable<Product> GetByName(string name);
    IEnumerable<Product> GetBySupplierId(int supplierId);
    IEnumerable<Product> GetByPrice(decimal Price);
    bool Delete(int id);
    Product GetById(int id);
    Product Update(int id, Product product);
    Product Add(Product product);
}