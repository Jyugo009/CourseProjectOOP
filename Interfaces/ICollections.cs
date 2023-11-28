namespace Interfaces
{
    public interface ICollections
    {
        int Count { get; }

        void Clear();

        bool Contains(object? item);

        void Add(object? item);

        object[]? ToArray();

    }
}
