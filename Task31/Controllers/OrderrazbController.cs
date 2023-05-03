using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderrazbController : ControllerBase
    {
        public onlineContext Context { get; }

        public OrderrazbController(onlineContext context)
        { Context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrderRazb> orderRazbs = Context.OrderRazbs.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            OrderRazb? orderRazb = Context.OrderRazbs.Where(x => x.IdProduct == id).FirstOrDefault();
            if (orderRazb == null)
            {
                return BadRequest("Not found");
            }
            return Ok(orderRazb);
        }

        [HttpPost]
        public IActionResult Add(OrderRazb orderRazb)
        {
            Context.OrderRazbs.Add(orderRazb);
            Context.SaveChanges();
            return Ok(orderRazb);
        }

        [HttpPut]
        public IActionResult Update(OrderRazb orderRazb)
        {
            Context.OrderRazbs.Update(orderRazb);
            Context.SaveChanges();
            return Ok(orderRazb);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            OrderRazb orderRazb = Context.OrderRazbs.Where(x => x.IdProduct == id).FirstOrDefault();
            if (orderRazb == null)
            {
                return BadRequest("Not found");
            }
            Context.OrderRazbs.Remove(orderRazb);
            Context.SaveChanges();
            return Ok();
        }
    }
}
