using Domain.Entities;
using SharedKernel.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Auditable<TUser> : BaseEntity where TUser : User
    {
        [ForeignKey("created_by")]
        public Guid created_by_id { get; protected set; }

        public DateTime record_date { get; protected set; }

        public TUser created_by { get; protected set; }

        public void SetAuditFields(Guid createdById)
        {
            created_by_id = createdById;
            record_date = DateTime.Now;
        }
    }
}