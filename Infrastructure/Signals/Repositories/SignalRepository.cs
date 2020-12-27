namespace JarvisTrading.Infrastructure.Signals.Repositories
{
    using AutoMapper;
    using JarvisTrading.Application.Signals;
    using JarvisTrading.Application.Signals.Queries;
    using JarvisTrading.Domain.Signals.Models;
    using JarvisTrading.Infrastructure.Common.Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SignalRepository : DataRepository<ISignalDbContext, Signal>, ISignalQueryRepository
    {
        private readonly IMapper _mapper;

        public SignalRepository(ISignalDbContext db, IMapper mapper)
            : base(db)
            => this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public Task<SignalOutputModel> GetSignals(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
