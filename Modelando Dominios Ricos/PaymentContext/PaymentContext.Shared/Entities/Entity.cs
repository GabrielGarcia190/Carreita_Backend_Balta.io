using Flunt.Notifications;

namespace PaymentContext.Shared
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}