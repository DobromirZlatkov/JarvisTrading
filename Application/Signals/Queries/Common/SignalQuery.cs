namespace JarvisTrading.Application.Signals.Queries.Common
{
    using JarvisTrading.Domain.Common;
    using JarvisTrading.Domain.Signals.Models;
    using JarvisTrading.Domain.Signals.Specifications.Signals;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class SignalQuery
    {
        private const int PageSize = 10;

        public int Page { get; set; } = 1;

        public abstract class SignalQueryHandler
        {
            protected readonly ISignalQueryRepository _signalsRepo;

            protected SignalQueryHandler(ISignalQueryRepository signalsRepo)
                => this._signalsRepo = signalsRepo ?? throw new ArgumentNullException(nameof(signalsRepo));

            protected async Task<int> GetTotalPages(
                SignalQuery request,
                Guid? receiverId = default,
                CancellationToken cancellationToken = default)
            {
                var specification = this.GetSignalsSpecification(request, receiverId);

                var result = await this._signalsRepo.Total(specification, cancellationToken);

                return result;
            }

            protected async Task<IEnumerable<TSignalOutputModel>> GetSignalsListings<TSignalOutputModel>(
                SignalQuery request,
                Guid? receiverId = default,
                CancellationToken cancellationToken = default)
            {
                var skip = (request.Page - 1) * PageSize;

                var specification = this.GetSignalsSpecification(request, receiverId);

                var result = await this._signalsRepo.GetSignalListings<TSignalOutputModel>(
                    specification,
                    skip,
                    PageSize,
                    cancellationToken);

                return result;
            }

            private Specification<Signal> GetSignalsSpecification(SignalQuery request, Guid? receiverId = default)
                => new NotReceivedSignalsSpecification(receiverId);

        }
    }
}
