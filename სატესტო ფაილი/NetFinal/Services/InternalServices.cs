using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class InternalServices:IInnerServices
{
    
    private readonly AppDbContext _context;
    
    public InternalServices(AppDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Product> GetAllPrdocucts()
    {
        return _context.Products.Include(x => x.Supplier).ToList(); 
    }

    public IEnumerable<Product> GetByName(string name)
    {
        return _context.Products.Where(x => x.Name.Contains(name)).ToList();
    }

    public IEnumerable<Product> GetBySupplierId(int supplierId)
    {
        return _context.Products.Where(x => x.SupplierId == supplierId).ToList();
    }

    public IEnumerable<Product> GetByPrice(decimal price)
    {
        return _context.Products.Where(x => x.Price > price).ToList();
    }

    public bool Delete(int id)
    {
        var a = _context.Products.Find(id);
        if (a == null) return false;
        _context.Products.Remove(a);
        _context.SaveChanges();
        return true;
    }

    public Product GetById(int id)
    {
        var a = _context.Products.Find(id);
        if (a == null) return null;
        return a;
    }

    public Product Update(int id, Product product)
    {
        var a = _context.Products.Find(id);
        if (a == null) return null;
        a.Name = product.Name;
        a.Price = product.Price;
        a.SupplierId = product.SupplierId;
        a.Name = product.Name;
        a.Stock = product.Stock;
        _context.SaveChanges();
        return a;
    }

    public Product Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }
}