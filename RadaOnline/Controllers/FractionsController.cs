using System.Web.Http;

namespace RadaOnline.Controllers
{
    using RadaOnline.Queries.Fraction.Interfaces;

    [RoutePrefix("api/Fractions")]
    public class FractionsController : ApiController
    {
        private readonly IFractionRetrieveQuery fractionRetrieveQuery;

        public FractionsController(IFractionRetrieveQuery fractionRetrieveQuery)
        {
            this.fractionRetrieveQuery = fractionRetrieveQuery;
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = this.fractionRetrieveQuery.Execute(id);

            return this.Ok(result);
        }
    }
}
