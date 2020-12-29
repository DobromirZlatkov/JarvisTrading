namespace JarvisTrading.Application.Signals
{
    using JarvisTrading.Application.Common.Contracts;
    using JarvisTrading.Domain.Common;
    using JarvisTrading.Domain.Signals.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ISignalQueryRepository : IQueryRepository<Signal>
    {
        Task<IEnumerable<TOutputModel>> GetSignalListings<TOutputModel>(
            Specification<Signal> signalSpecification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<int> Total(
           Specification<Signal> signalSpecification,
           CancellationToken cancellationToken = default);
    }
}
