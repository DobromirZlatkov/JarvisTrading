namespace JarvisTrading.Domain.Signals.Models
{
    using JarvisTrading.Domain.Common;
    using JarvisTrading.Domain.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Signal: Entity<Guid>, IAggregateRoot
    {
        private readonly HashSet<Update> updates;

        private readonly HashSet<Receiver> receivedBy;

        public Signal(string sourceMessage, string asset, double price, double stopLoss, double takeProfit, string magic, SignalType signalType)
        {
            this.Asset = asset;
            this.Price = price;
            this.StopLoss = stopLoss;
            this.TakeProfit = takeProfit;
            this.Magic = magic;
            this.SignalType = signalType;
            this.SourceMessage = sourceMessage;

            this.updates = new HashSet<Update>();
            this.receivedBy = new HashSet<Receiver>();
        }

        // TODO add profit

        public string SourceMessage { get; private set; }

        public Source? SourceType { get; private set; }

        public string Asset { get; private set; }

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
        public string Magic { get; private set; }

        public SignalType SignalType { get; private set; }

        public IReadOnlyCollection<Update> Updates => this.updates.ToList().AsReadOnly();

        public IReadOnlyCollection<Receiver> ReceivedBy => this.receivedBy.ToList().AsReadOnly();
    }
}
