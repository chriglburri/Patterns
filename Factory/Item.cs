namespace Factory
{
    public class Item
    {
        public Item(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }

        // This is the entrypoint for the factory. No registration needed! AutoFac ;)
        public delegate Item Factory(int id, string name);
    }
}
