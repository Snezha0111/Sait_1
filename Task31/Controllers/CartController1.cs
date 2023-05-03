using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController1 : ControllerBase
    {
        public onlineContext Context { get; }

        public CartController1(onlineContext context)
        { Context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Cart> carts = Context.Carts.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Cart? cart = Context.Carts.Where(x => x.IdProduct == id).FirstOrDefault();
            if (cart == null)
            {
                return BadRequest("Not found");
            }
            return Ok(cart);
        }

        [HttpPost]
        public IActionResult Add(Cart cart)
        {
            Context.Carts.Add(cart);
            Context.SaveChanges();
            return Ok(cart);
        }

        [HttpPut]
        public IActionResult Update(Cart cart)
        {
            Context.Carts.Update(cart);
            Context.SaveChanges();
            return Ok(cart);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Cart? cart = Context.Carts.Where(x => x.IdProduct == id).FirstOrDefault();
            if (cart == null)
            {
                return BadRequest("Not found");
            }
            Context.Carts.Remove(cart);
            Context.SaveChanges();
            return Ok();
        }
    }
}
