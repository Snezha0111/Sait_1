using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryRazbController : ControllerBase
    {
        public onlineContext Context { get; }

        public DeliveryRazbController(onlineContext context)
        { Context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<DeliveryRazb> deliveryrazbs = Context.DeliveryRazbs.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            DeliveryRazb? deliveryrazbs = Context.DeliveryRazbs.Where(x => x.IdOrder == id).FirstOrDefault();
            if (deliveryrazbs == null)
            {
                return BadRequest("Not found");
            }
            return Ok(deliveryrazbs);
        }

        [HttpPost]
        public IActionResult Add(DeliveryRazb deliveryrazb)
        {
            Context.DeliveryRazbs.Add(deliveryrazb);
            Context.SaveChanges();
            return Ok(deliveryrazb);
        }

        [HttpPut]
        public IActionResult Update(DeliveryRazb deliveryrazb)
        {
            Context.DeliveryRazbs.Update(deliveryrazb);
            Context.SaveChanges();
            return Ok(deliveryrazb);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            DeliveryRazb deliveryrazbs = Context.DeliveryRazbs.Where(x => x.IdOrder == id).FirstOrDefault();
            if (deliveryrazbs == null)
            {
                return BadRequest("Not found");
            }
            Context.DeliveryRazbs.Remove(deliveryrazbs);
            Context.SaveChanges();
            return Ok();
        }
    }
}
