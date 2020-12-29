namespace JarvisTrading.Application.Signals.Queries.Mine
{
    using JarvisTrading.Application.Signals.Queries.Common;
    using System.Collections.Generic;

    public class MineSignalsOutputModel : SignalsOutputModel<MineSignalOutputModel>
    {
        public MineSignalsOutputModel(IEnumerable<MineSignalOutputModel> signals, int page, int totalPages)
            : base(signals, page, totalPages)
        {
        }
    }
}
