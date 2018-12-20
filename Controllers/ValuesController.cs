using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ThreadFun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "LastDelay", $"{WorkForTime.LastDelay}" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            string result = Task.Run(() => ThreadFun.WorkForTime.DoWork(id)).ConfigureAwait(false).GetAwaiter().GetResult();
            return $"Finished with {result}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] string value)
        {
            //int.TryParse(value, out int numSecs);
            //string result = 
            ThreadFun.WorkForTime.DoWork(id);//.ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine($"Finished with No waiting.");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
