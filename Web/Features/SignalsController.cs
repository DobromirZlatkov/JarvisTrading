namespace JarvisTrading.Web.Features
{
    using JarvisTrading.Application.Signals.Queries.Mine;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class SignalsController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<ActionResult<MineSignalsOutputModel>> Mine([FromQuery] MineSignalsQuery query)
            => await this.Send(query);
    }
}
