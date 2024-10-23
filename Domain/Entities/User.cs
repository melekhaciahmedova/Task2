using Domain.Entities.RoleAggregate;
using SharedKernel.Domain.SeedWork;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string? RefreshToken {  get; private set; }
        public bool IsDeleted {  get; private set; }
        public Role Role { get; private set; }
        public Guid RoleId { get; private set; }

        public void SetDetails(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void SetRole(Guid id)
        {
            RoleId = id;
        }
        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}