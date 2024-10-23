using SharedKernel.Domain.SeedWork;

namespace Domain.Entities.RoleAggregate
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private readonly List<User> _users = [];
        public IReadOnlyCollection<User> Users => _users;
    }
}