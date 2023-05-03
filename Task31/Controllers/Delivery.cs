using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryC : ControllerBase
    {
         public onlineContext Context { get; }

        public DeliveryC(onlineContext context)
        { Context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Delivery> deliveries = Context.Deliveries.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Delivery? delivery = Context.Deliveries.Where(x => x.IdOrder == id).FirstOrDefault();
            if (delivery == null)
            {
                return BadRequest("Not found");
            }
            return Ok(delivery);
        }

        [HttpPost]
        public IActionResult Add(Delivery delivery)
        {
            Context.Deliveries.Add(delivery);
            Context.SaveChanges();
            return Ok(delivery);
        }

        [HttpPut]
        public IActionResult Update(Delivery delivery)
        {
            Context.Deliveries.Update(delivery);
            Context.SaveChanges();
            return Ok(delivery);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Delivery delivery = Context.Deliveries.Where(x => x.IdOrder == id).FirstOrDefault();
            if (delivery == null)
            {
                return BadRequest("Not found");
            }
            Context.Deliveries.Remove(delivery);
            Context.SaveChanges();
            return Ok();
        }
    }
}
