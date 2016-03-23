using System.Web.Http;

namespace RadaOnline.Controllers
{
    using RadaOnline.Models;
    using RadaOnline.Queries.Council.Interfaces;
    using RadaOnline.Queries.Councilman.Interfaces;
    using RadaOnline.Queries.Fraction.Interfaces;

    [RoutePrefix("api/Councils")]
    public class CouncilsController : ApiController
    {
        private readonly ICouncilOverviewQuery councilOverviewQuery;
        private readonly ICouncilRetrieveQuery councilRetrieveQuery;
        private readonly ICouncilmanOverviewQuery councilmanOverviewQuery;
        private readonly IFractionOverviewQuery fractionOverviewQuery;

        public CouncilsController(ICouncilOverviewQuery councilOverviewQuery, ICouncilRetrieveQuery councilRetrieveQuery, ICouncilmanOverviewQuery councilmanOverviewQuery, IFractionOverviewQuery fractionOverviewQuery)
        {
            this.councilOverviewQuery = councilOverviewQuery;
            this.councilRetrieveQuery = councilRetrieveQuery;
            this.councilmanOverviewQuery = councilmanOverviewQuery;
            this.fractionOverviewQuery = fractionOverviewQuery;
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

        [Route("{id:int}/Councilmen")]
        [HttpGet]
        public IHttpActionResult GetCouncilmen(int id, [FromUri] CouncilmanOverviewRequest model)
        {
            const int DefaultTake = 100;
            const int DefaultSkip = 0;

            var result = this.councilmanOverviewQuery.Execute(
                id,
                model?.FractionId,
                model?.Name,
                model?.Take ?? DefaultTake,
                model?.Skip ?? DefaultSkip);

            return this.Ok(result);
        }

        [Route("{id:int}/Fractions")]
        [HttpGet]
        public IHttpActionResult GetFractions(int id, [FromUri] FractionOverviewRequest model)
        {
            const int DefaultTake = 100;
            const int DefaultSkip = 0;

            var result = this.fractionOverviewQuery.Execute(
                id,
                model?.Name,
                model?.Take ?? DefaultTake,
                model?.Skip ?? DefaultSkip);

            return this.Ok(result);
        }
    }
}
