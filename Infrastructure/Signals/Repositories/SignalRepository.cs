namespace JarvisTrading.Infrastructure.Signals.Repositories
{
    using AutoMapper;
    using JarvisTrading.Application.Signals;
    using JarvisTrading.Domain.Common;
    using JarvisTrading.Domain.Signals.Models;
    using JarvisTrading.Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SignalRepository : DataRepository<ISignalDbContext, Signal>, ISignalQueryRepository
    {
        private readonly IMapper _mapper;

        public SignalRepository(ISignalDbContext db, IMapper mapper)
            : base(db)
            => this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<IEnumerable<TOutputModel>> GetSignalListings<TOutputModel>(Specification<Signal> signalSpecification, int skip = 0, int take = int.MaxValue, CancellationToken cancellationToken = default)
        {
            var query = this.Data.Signals.Where(signalSpecification);

            var result = await this._mapper.ProjectTo<TOutputModel>(query).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<int> Total(Specification<Signal> signalSpecification, CancellationToken cancellationToken = default)
        {
            var result = await this.Data.Signals.Where(signalSpecification).CountAsync(cancellationToken);

            return result;
        }
    }
}
