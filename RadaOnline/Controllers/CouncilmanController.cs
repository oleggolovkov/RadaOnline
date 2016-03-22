namespace RadaOnline.Controllers
{
    using System.Web.Http;

    using RadaOnline.Queries.Councilman.Interfaces;

    public class CouncilmanController : ApiController
    {
        private readonly IConcilmanGetListQuery councilmanGetListQuery;

        public CouncilmanController(IConcilmanGetListQuery councilmanGetListQuery)
        {
            this.councilmanGetListQuery = councilmanGetListQuery;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.councilmanGetListQuery.Execute());
        }
    }
}
