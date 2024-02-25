namespace Factory
{
    public class Items : IItems
    {
        private IList<Item> _innerCollection = new List<Item>();
        private Item.Factory _createItem;

        public Items(Item.Factory createItem)
        {
            _createItem = createItem ?? throw new ArgumentNullException(nameof(createItem));
        }

        public void Create(int n)
        {
            foreach (var i in Enumerable.Range(1, n))
            {
                Console.Write($"Creating item {i} of {n}. Name=...?");
                _innerCollection.Add(_createItem(i, Console.ReadLine()));
            }
        }
    }
}
