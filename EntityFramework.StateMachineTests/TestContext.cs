using Microsoft.EntityFrameworkCore;

namespace EntityFramework.StateMachineTests
{
    public class TestContext : DbContext
    {
        public DbSet<Delivery> Deliveries { get; set; }
    }
}