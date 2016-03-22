namespace RadaOnline.Controllers
{
    using System.Web.Http;

    public class CouncilmanController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("List of concilmen");
        }
    }
}
