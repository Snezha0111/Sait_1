using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointofissueController : ControllerBase
    {
        public onlineContext Context { get; }

        public PointofissueController(onlineContext context)
        { Context = context; }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<PointOfIssue> pointOfIssues = Context.PointOfIssues.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PointOfIssue? pointOfIssue = Context.PointOfIssues.Where(x => x.IdPoint == id).FirstOrDefault();
            if (pointOfIssue == null)
            {
                return BadRequest("Not found");
            }
            return Ok(pointOfIssue);
        }

        [HttpPost]
        public IActionResult Add(PointOfIssue pointOfIssue)
        {
            Context.PointOfIssues.Add(pointOfIssue);
            Context.SaveChanges();
            return Ok(pointOfIssue);
        }

        [HttpPut]
        public IActionResult Update(PointOfIssue pointOfIssue)
        {
            Context.PointOfIssues.Update(pointOfIssue);
            Context.SaveChanges();
            return Ok(pointOfIssue);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            PointOfIssue pointOfIssue = Context.PointOfIssues.Where(x => x.IdPoint == id).FirstOrDefault();
            if (pointOfIssue == null)
            {
                return BadRequest("Not found");
            }
            Context.PointOfIssues.Remove(pointOfIssue);
            Context.SaveChanges();
            return Ok();
        }
    }
}
