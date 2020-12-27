namespace JarvisTrading.Application.Signals
{
    using JarvisTrading.Application.Common.Contracts;
    using JarvisTrading.Application.Signals.Queries;
    using JarvisTrading.Domain.Signals.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ISignalQueryRepository : IQueryRepository<Signal>
    {
        Task<SignalOutputModel> GetSignals(int id, CancellationToken cancellationToken = default);
    }
}
