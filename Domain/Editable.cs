using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    /// <summary>
    /// Editable requires user to work.
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    public class Editable<TUser> : Auditable<TUser> where TUser : User
    {
        [ForeignKey("updated_by")]
        public Guid? updated_by_id { get; protected set; }

        public DateTime? last_update_date { get; protected set; }

        public TUser updated_by { get; protected set; }

        public void SetEditFields(Guid? updatedById)
        {
            updated_by_id = updatedById;
            last_update_date = DateTime.Now;
        }
    }
}