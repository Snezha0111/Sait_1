using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderproductController : ControllerBase
    {
        public onlineContext Context { get; }

        public ProviderproductController(onlineContext context)
        { Context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProviderProduct> providerProducts = Context.ProviderProducts.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProviderProduct? providerProduct = Context.ProviderProducts.Where(x => x.IdProvider == id).FirstOrDefault();
            if (providerProduct == null)
            {
                return BadRequest("Not found");
            }
            return Ok(providerProduct);
        }

        [HttpPost]
        public IActionResult Add(ProviderProduct providerProduct)
        {
            Context.ProviderProducts.Add(providerProduct);
            Context.SaveChanges();
            return Ok(providerProduct);
        }

        [HttpPut]
        public IActionResult Update(ProviderProduct providerProduct)
        {
            Context.ProviderProducts.Update(providerProduct);
            Context.SaveChanges();
            return Ok(providerProduct);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ProviderProduct providerProduct = Context.ProviderProducts.Where(x => x.IdProvider == id).FirstOrDefault();
            if (providerProduct == null)
            {
                return BadRequest("Not found");
            }
            Context.ProviderProducts.Remove(providerProduct);
            Context.SaveChanges();
            return Ok();
        }
    }
}
