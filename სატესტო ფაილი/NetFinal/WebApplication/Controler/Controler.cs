using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;

namespace YourProjectNamespace.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IInnerServices _innerServices;

    public ProductsController(IInnerServices innerServices)
    {
        _innerServices = innerServices;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll() => Ok(_innerServices.GetAllPrdocucts());

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _innerServices.GetById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet("search/name/{name}")]
    public ActionResult<IEnumerable<Product>> GetByName(string name) => Ok(_innerServices.GetByName(name));

    [HttpGet("search/supplier/{supplierId}")]
    public ActionResult<IEnumerable<Product>> GetBySupplierId(int supplierId) => Ok(_innerServices.GetBySupplierId(supplierId));

    [HttpGet("search/price-above/{price}")]
    public ActionResult<IEnumerable<Product>> GetByPrice(decimal price) => Ok(_innerServices.GetByPrice(price));

    [HttpPost]
    public ActionResult<Product> Add([FromBody] Product product)
    {
        var created = _innerServices.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update(int id, [FromBody] Product product)
    {
        var updated = _innerServices.Update(id, product);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_innerServices.Delete(id)) return NotFound();
        return NoContent();
    }
}