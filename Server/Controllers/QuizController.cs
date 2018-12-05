using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private IMemoryCache _cache;
        public QuizController(IMemoryCache cache)
        {
            _cache = cache;
        }


        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine(DateTime.Now.ToString());
            return new JsonResult(GetQuizzes().Select(x => x.Id));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            var q = GetQuizzes();
            return new JsonResult(q.SingleOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public string Post([FromBody] Quiz c)
        {
            Console.WriteLine(JsonConvert.SerializeObject(c, Formatting.Indented));
            c.Id = Guid.NewGuid().ToString();

            var qs = GetQuizzes();
            qs.Add(c);
            _cache.Set("quizes", qs);

            return c.Id;
        }

        private List<Quiz> GetQuizzes() => _cache.Get("quizes") as List<Quiz> ?? new List<Quiz>();
    }
}