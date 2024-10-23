using SharedKernel.Domain.Seedwork;

namespace Domain.Entities.RoleAggregate
{
    public class RoleParameter : Enumeration
    {
        public static RoleParameter SuperAdmin = new(Guid.Parse("20de9c25-cd28-47cf-b205-ea19430e00f2"), RoleName.SuperAdmin);
        public static RoleParameter Student = new(Guid.Parse("3183edd2-ab36-4ab3-9fbe-3f3f08dae974"), RoleName.Admin);
        public static RoleParameter Teacher = new(Guid.Parse("8929c640-f9df-4dbb-b862-d9f907be69ee"), RoleName.User);

        public RoleParameter(Guid id, string name) : base(id, name)
        {

        }

        public RoleParameter()
        {

        }
    }
}