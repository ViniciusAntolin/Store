using Flunt.Notifications;

namespace Store.Store.Domain.Entities
{
    public class Entidade : Notifiable<Notification>
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
