using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleLoggingClient.LoggingInterfaces;
using static SimpleLoggingInterfaces.Enums.EnumCollection;

namespace TestLoggingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILog _log;

        public ValuesController(ILog log)
        {
            _log = log;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _log.InternalTransaction.Message(LogLevel.Info, null, null, null, "This is a test", true);
            _log.InternalTransaction.Message(LogLevel.Info, "Test", "test 2", "www.test.com", "This is a test", true);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}