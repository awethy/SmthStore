namespace SmthStore.Core.Models
{
    public class Smth
    {
        public const int MAX_NAME_LENGTH = 200;
        private Smth(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        public static (Smth Smth, string Error) Create(Guid id, string name, string description)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be empty or longer then 200 symbols!";
            }

            var smth = new Smth(id, name, description);

            return (smth, error);
        }
    }
}
