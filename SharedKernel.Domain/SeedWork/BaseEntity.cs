namespace SharedKernel.Domain.SeedWork
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}