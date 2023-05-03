using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order1Controller : ControllerBase
    {
        public onlineContext Context { get; }

        public Order1Controller(onlineContext context)
        { Context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Order1> order1 = Context.Order1s.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Order1? order1 = Context.Order1s.Where(x => x.IdOrder == id).FirstOrDefault();
            if (order1 == null)
            {
                return BadRequest("Not found");
            }
            return Ok(order1);
        }

        [HttpPost]
        public IActionResult Add(Order1 order1)
        {
            Context.Order1s.Add(order1);
            Context.SaveChanges();
            return Ok(order1);
        }

        [HttpPut]
        public IActionResult Update(Order1 order1)
        {
            Context.Order1s.Update(order1);
            Context.SaveChanges();
            return Ok(order1);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Order1? order1 = Context.Order1s.Where(x => x.IdOrder == id).FirstOrDefault();
            if (order1 == null)
            {
                return BadRequest("Not found");
            }
            Context.Order1s.Remove(order1);
            Context.SaveChanges();
            return Ok();
        }
    }
}
