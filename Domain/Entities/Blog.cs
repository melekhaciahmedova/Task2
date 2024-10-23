using SharedKernel.Domain.SeedWork;

namespace Domain.Entities
{
    public class Blog : Editable<User>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public void SetDetails(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}