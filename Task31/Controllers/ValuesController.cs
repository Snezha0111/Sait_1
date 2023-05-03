using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        public onlineContext Context { get; }

        public RecipientController(onlineContext context)
        { Context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Recipient> recipients = Context.Recipients.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Recipient? recipient = Context.Recipients.Where(x => x.IdRec == id).FirstOrDefault();
            if (recipient == null)
            {
                return BadRequest("Not found");
            }
            return Ok(recipient);
        }

        [HttpPost]
        public IActionResult Add(Recipient recipient)
        {
            Context.Recipients.Add(recipient);
            Context.SaveChanges();
            return Ok(recipient);
        }

        [HttpPut]
        public IActionResult Update(Recipient recipient)
        {
            Context.Recipients.Update(recipient);
            Context.SaveChanges();
            return Ok(recipient);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Recipient recipient = Context.Recipients.Where(x => x.IdRec == id).FirstOrDefault();
            if (recipient == null)
            {
                return BadRequest("Not found");
            }
            Context.Recipients.Remove(recipient);
            Context.SaveChanges();
            return Ok();
        }
    }
}
