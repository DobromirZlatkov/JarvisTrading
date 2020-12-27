namespace JarvisTrading.Web.Features
{
    using JarvisTrading.Application.Signals.Queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SignalsController : ApiController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SignalOutputModel>>> Signals([FromQuery] GetSignalsQuery query)
            => await this.Send(query);
    }
}
