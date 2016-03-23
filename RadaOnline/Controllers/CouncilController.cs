using System.Web.Http;

namespace RadaOnline.Controllers
{
    using RadaOnline.Models;
    using RadaOnline.Queries.Council.Interfaces;

    [RoutePrefix("api/Council")]
    public class CouncilController : ApiController
    {
        private readonly ICouncilOverviewQuery councilOverviewQuery;
        private readonly ICouncilRetrieveQuery councilRetrieveQuery;

        public CouncilController(ICouncilOverviewQuery councilOverviewQuery, ICouncilRetrieveQuery councilRetrieveQuery)
        {
            this.councilOverviewQuery = councilOverviewQuery;
            this.councilRetrieveQuery = councilRetrieveQuery;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] CouncilOverviewRequest model)
        {
            const int DefaultTake = 100;
            const int DefaultSkip = 0;

            var result = this.councilOverviewQuery.Execute(
                model?.Name,
                model?.Take ?? DefaultTake,
                model?.Skip ?? DefaultSkip);

            return this.Ok(result);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = this.councilRetrieveQuery.Execute(id);

            return this.Ok(result);
        }
    }
}
