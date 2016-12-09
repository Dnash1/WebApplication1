using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace WebApplication1.Controllers
{
    public class ResponseItem
    {
        public string ActorName { get; set; }
        public string MovieName { get; set; }
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        [SwaggerOperation("GetAll")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IEnumerable<ResponseItem> Get(string id)
        {
            WebRequest ActorReq = WebRequest.Create("https://api.themoviedb.org/3/search/person?api_key=6614f88415a7eeb7f3b865101aff56de&language=en-US&query=Brad%20Pitt&page=1&include_adult=false");
            WebResponse ActorRes = ActorReq.GetResponse();
            yield return new ResponseItem
            {
                ActorName = ActorRes.results."profile_path",
                MovieName = "blah"
            };
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(int id)
        {
        }
    }
}
