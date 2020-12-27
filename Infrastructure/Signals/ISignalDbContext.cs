namespace JarvisTrading.Infrastructure.Signals
{
    using JarvisTrading.Domain.Signals.Models;
    using JarvisTrading.Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;

    internal interface ISignalDbContext : IDbContext
    {
        DbSet<Signal> Signals { get; }

        DbSet<Receiver> Receivers { get; }

        DbSet<Source> Sources { get; }

        DbSet<Update> Updates { get; }
    }
}
