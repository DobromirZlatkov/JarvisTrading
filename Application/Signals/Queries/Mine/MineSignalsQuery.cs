namespace JarvisTrading.Application.Signals.Queries.Mine
{
    using JarvisTrading.Application.Common.Contracts;
    using JarvisTrading.Application.Signals.Queries.Common;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class MineSignalsQuery : SignalQuery, IRequest<MineSignalsOutputModel>
    {
        public class MineCarAdsQueryHandler : SignalQueryHandler, IRequestHandler<MineSignalsQuery, MineSignalsOutputModel>
        {
            private readonly ICurrentUser _currentUser;

            public MineCarAdsQueryHandler(ISignalQueryRepository signalRepo, ICurrentUser currentUser)
                :base(signalRepo)
            {
                _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            }

            public async Task<MineSignalsOutputModel> Handle(MineSignalsQuery request, CancellationToken cancellationToken)
            {
                var receiverId = Guid.Parse(_currentUser.UserId);

                var signalsListings = await base.GetSignalsListings<MineSignalOutputModel>(
                    request,
                    receiverId,
                    cancellationToken);
                    
                var totalPages = await base.GetTotalPages(
                    request,
                    receiverId,
                    cancellationToken);

                return new MineSignalsOutputModel(signalsListings, request.Page, totalPages);
            }
        }
    }
}
