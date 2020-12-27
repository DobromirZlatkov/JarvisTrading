namespace JarvisTrading.Application.Signals.Queries
{
    using JarvisTrading.Application.Common.Contracts;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetSignalsQuery : IRequest<IEnumerable<SignalOutputModel>>
    {
        public class MineCarAdsQueryHandler : IRequestHandler<GetSignalsQuery, IEnumerable<SignalOutputModel>>
        {
            private readonly ISignalQueryRepository _signalRepo;
            private readonly ICurrentUser _currentUser;

            public MineCarAdsQueryHandler(ISignalQueryRepository signalRepo, ICurrentUser currentUser)
            {
                _signalRepo = signalRepo ?? throw new ArgumentNullException(nameof(signalRepo));
                _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            }

            public Task<IEnumerable<SignalOutputModel>> Handle(GetSignalsQuery request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
