namespace JarvisTrading.Application.Signals.Queries.Common
{
    using System.Collections.Generic;

    public abstract class SignalsOutputModel<TSignalOutputModel>
    {
        internal SignalsOutputModel(
           IEnumerable<TSignalOutputModel> signals,
           int page,
           int totalPages)
        {
            this.Signals = signals;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TSignalOutputModel> Signals { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
