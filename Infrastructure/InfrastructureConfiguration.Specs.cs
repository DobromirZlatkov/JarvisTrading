﻿namespace JarvisTrading.Infrastructure
{
    using System;
    using System.Reflection;
    using Application.Dealerships.CarAds;
    using AutoMapper;
    using Common.Events;
    using Common.Persistence;
    using Dealership;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<JarvisTradingDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IDealershipDbContext>(provider => provider
                    .GetService<JarvisTradingDbContext>())
                .AddTransient<IEventDispatcher, EventDispatcher>();

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<ICarAdQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
