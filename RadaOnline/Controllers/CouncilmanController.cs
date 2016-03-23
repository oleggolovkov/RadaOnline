namespace RadaOnline.Controllers
{
    using System.Web.Http;

    using RadaOnline.Attributes;
    using RadaOnline.Models;
    using RadaOnline.Queries.Councilman.Interfaces;

    [RoutePrefix("api/Councilman")]
    public class CouncilmanController : ApiController
    {
        private readonly ICouncilmanOverviewQuery councilmanGetListQuery;
        private readonly ICouncilmanRetrieveQuery councilmanRetrieveQuery;

        public CouncilmanController(ICouncilmanOverviewQuery councilmanGetListQuery, ICouncilmanRetrieveQuery councilmanRetrieveQuery)
        {
            this.councilmanGetListQuery = councilmanGetListQuery;
            this.councilmanRetrieveQuery = councilmanRetrieveQuery;
        }

        [Route("")]
        [HttpGet]
        [ValidateModel]
        public IHttpActionResult Get([FromUri] CouncilmanGetListRequest model)
        {
            const int DefaultTake = 100;
            const int DefaultSkip = 0;

            var result = this.councilmanGetListQuery.Execute(
                model.CouncilId,
                model.FractionId,
                model.Name,
                model.Take ?? DefaultTake,
                model.Skip ?? DefaultSkip);

            return this.Ok(result);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = this.councilmanRetrieveQuery.Execute(id);

            return this.Ok(result);
        }
    }
}
