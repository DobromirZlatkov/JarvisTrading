namespace JarvisTrading.Domain.Signals.Models
{
    using JarvisTrading.Domain.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Source : Entity<Guid>
    {
        private readonly HashSet<Signal> signals;

        public Source(string name)
        {
            this.Name = name;
            this.signals = new HashSet<Signal>();
        }
        public string Name { get; private set; }

        public IReadOnlyCollection<Signal> Signals => this.signals.ToList().AsReadOnly();
    }
}
