namespace RadaOnline.Controllers
{
    using System.Web.Http;

    using RadaOnline.Queries.Session.Interfaces;

    [RoutePrefix("api/Sessions")]
    public class SessionsController : ApiController
    {
        private readonly ISessionRetrieveQuery sessionRetrieveQuery;

        public SessionsController(ISessionRetrieveQuery sessionRetrieveQuery)
        {
            this.sessionRetrieveQuery = sessionRetrieveQuery;
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = this.sessionRetrieveQuery.Execute(id);

            return this.Ok(result);
        }
    }
}
