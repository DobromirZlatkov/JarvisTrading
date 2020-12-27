namespace JarvisTrading.Domain.Signals.Models
{
    using JarvisTrading.Domain.Common.Models;
    using System;

    public class Update : Entity<Guid>
    {
        public Update(string sourceMessage)
        {
            this.SourceMessage = sourceMessage;
        }
        public string SourceMessage { get; private set; }
    }
}
