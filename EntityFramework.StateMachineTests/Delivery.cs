using EntityFramework.StateMachine;

namespace EntityFramework.StateMachineTests
{

    public enum DeliveryStatus
    {
        Ordered,
        Dispatched,
        Delivered,
        Deleted
    }

    public enum DeliverAction
    {
        Delete,
        Release,
        Receive
    }

    public class Delivery: StateEntity<DeliveryStatus, DeliverAction>
    {
        public Delivery()
        {
            State.Configure(DeliveryStatus.Ordered)
                .Permit(DeliverAction.Release, DeliveryStatus.Dispatched)
                .Permit(DeliverAction.Delete, DeliveryStatus.Deleted);
                

            State.Configure(DeliveryStatus.Dispatched)
                .Permit(DeliverAction.Receive, DeliveryStatus.Delivered);

            State.Configure(DeliveryStatus.Deleted)
                .OnEntry(() => IsDeleted = true);
        }

        public int DeliveryId { get; set; }

        public bool IsDeleted { get; set; }
    }
}