namespace JarvisTrading.Domain.Signals.Specifications.Signals
{
    using JarvisTrading.Domain.Common;
    using JarvisTrading.Domain.Signals.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class NotReceivedSignalsSpecification : Specification<Signal>
    {
        private readonly Guid? receiverId;

        public NotReceivedSignalsSpecification(Guid? receiverId)
            => this.receiverId = receiverId;

        protected override bool Include => this.receiverId != null;

        public override Expression<Func<Signal, bool>> ToExpression()
            => signal => !signal.ReceivedBy.Any(x => x.UserId == this.receiverId);
    }
}
