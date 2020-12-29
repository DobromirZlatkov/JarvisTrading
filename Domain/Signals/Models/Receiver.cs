namespace JarvisTrading.Domain.Signals.Models
{
    using JarvisTrading.Domain.Common.Models;
    using System;

    public class Receiver : Entity<Guid>
    {
        public Receiver(Guid userId, string email)
        {
            this.Email = email;
            this.UserId = userId;
        }

        // TODO receiverId
        public Guid UserId { get; set; }

        public string Email { get; set; }
    }
}
