namespace RadaOnline.Controllers
{
    using System.Web.Http;
    using RadaOnline.Queries.Councilman.Interfaces;

    [RoutePrefix("api/Councilmen")]
    public class CouncilmenController : ApiController
    {
        private readonly ICouncilmanRetrieveQuery councilmanRetrieveQuery;

        public CouncilmenController(ICouncilmanRetrieveQuery councilmanRetrieveQuery)
        {
            this.councilmanRetrieveQuery = councilmanRetrieveQuery;
        }

        /// <summary>
        /// Details of the councilman
        /// </summary>
        /// <param name="id">councilmanId</param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = this.councilmanRetrieveQuery.Execute(id);

            return this.Ok(result);
        }
    }
}
