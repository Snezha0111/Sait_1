using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pr_gus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new List<string>()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get() // готовый вывод
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name) // добавление
        {
            if (name.Length > 50)
                return BadRequest("Слишком большая длина. Введите имя покороче");
            Summaries.Add(name);
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(int index, string name) // обновление
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Неверный индекс");
            Summaries[index] = name;
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int index) // удаление
        {
            if (index < 0 || index > Summaries.Count)
                return BadRequest("Неверный индекс");
            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public string GetInd(int index)
        {
            if(index < 0 || index >= Summaries.Count)
               return "Введен неверный текст";
            return Summaries[index];
        }

        [HttpGet("{find-by-name}")]
        public int GetName(string name)
        {
            int shetchik = 0;
            for (int i = 0; i < Summaries.Count; i++)
            {
                if (Summaries[i] == name)
                    shetchik++;
            }
            return shetchik;
        }

        [HttpGet("{GetAll}")]
        public IActionResult GetAll(int? strategy)
        {
            if (strategy == null)
                return (IActionResult)Summaries;
            if (Summaries.Count == 1)
            {
                Summaries.Sort();
                return (IActionResult)Summaries;
            }
            if (Summaries.Count == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return (IActionResult)Summaries;
            }
            return BadRequest("Некорректное значение параметра sortStrategy");
        }
    }
}
