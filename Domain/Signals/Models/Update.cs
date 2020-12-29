namespace JarvisTrading.Domain.Signals.Models
{
    using JarvisTrading.Domain.Common.Models;
    using System;

    public class Update : Entity<Guid>
    {
        // TODO add update info like update action, price etc, the client will ping for updates per signal
        public Update(string sourceMessage)
        {
            this.SourceMessage = sourceMessage;
        }
        public string SourceMessage { get; private set; }
    }
}
