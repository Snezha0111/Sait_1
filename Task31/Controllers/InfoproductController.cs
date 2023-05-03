using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoproductController : ControllerBase
    {
        public onlineContext Context { get; }

        public InfoproductController(onlineContext context)
        { Context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<InfoProduct> infoProducts = Context.InfoProducts.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            InfoProduct? infoProduct = Context.InfoProducts.Where(x => x.IdProduct == id).FirstOrDefault();
            if (infoProduct == null)
            {
                return BadRequest("Not found");
            }
            return Ok(infoProduct);
        }

        [HttpGet("{category}")]
        public IActionResult GetByCat(string category)
        {
            InfoProduct? infoProduct = Context.InfoProducts.Where(x => x.Category == category).FirstOrDefault();
            if (infoProduct == null)
            {
                return BadRequest("Not found");
            }
            return Ok(infoProduct);
        }

        [HttpPost]
        public IActionResult Add(InfoProduct infoProduct)
        {
            Context.InfoProducts.Add(infoProduct);
            Context.SaveChanges();
            return Ok(infoProduct);
        }

        [HttpPut]
        public IActionResult Update(InfoProduct infoProduct)
        {
            Context.InfoProducts.Update(infoProduct);
            Context.SaveChanges();
            return Ok(infoProduct);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            InfoProduct infoProduct = Context.InfoProducts.Where(x => x.IdProduct == id).FirstOrDefault();
            if (infoProduct == null)
            {
                return BadRequest("Not found");
            }
            Context.InfoProducts.Remove(infoProduct);
            Context.SaveChanges();
            return Ok();
        }
    }
}
