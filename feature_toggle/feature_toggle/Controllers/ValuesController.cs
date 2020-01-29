using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace feature_toggle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;

        public ValuesController(IFeatureManager featureManger)
        {
            _featureManager = featureManger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var featureToggleTest = _featureManager.IsEnabled("BooleanTest")
                ? "true"
                : "false";

            return new string[] { featureToggleTest };
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
