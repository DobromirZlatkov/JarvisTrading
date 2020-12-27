namespace JarvisTrading.Application.Signals.Queries
{
    using JarvisTrading.Application.Common.Mapping;
    using JarvisTrading.Domain.Signal.Models;
    using System;
    using System.Collections.Generic;

    public class SignalOutputModel : IMapFrom<Signal>
    {
        public string SourceMessage { get; private set; } = default!;

        public string Asset { get; private set; } = default!;

        public double Price { get; private set; }

        public double StopLoss { get; private set; }

        public double TakeProfit { get; private set; }

        /// <summary>
        /// Result in pips
        /// </summary>
        public double Result { get; set; }

        public DateTime OpenTime { get; set; }

        public DateTime? CloseTime { get; set; }

        /// <summary>
        /// This is a unique string that is corelated to the signal
        /// </summary>
        public string Magic { get; private set; } = default!;

        public SignalType SignalType { get; private set; } = default!;

        public IReadOnlyCollection<Update> Updates { get; private set; } = default!;
    }
}
