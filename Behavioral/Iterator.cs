namespace Behavioral.Iterator 
{
    // Aggregate
    public interface IAggregate
    {
        IIterator CreateIterator();
    }

    // ConcreteAggregate
    public class ConcreteAggregate : IAggregate
    {
        private int[] _items;

        public ConcreteAggregate()
        {
            _items = new int[5] { 1, 2, 3, 4, 5 };
        }

        public IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return _items.Length; }
        }

        public int this[int index]
        {
            get { return _items[index]; }
        }
    }

    // Iterator
    public interface IIterator
    {
        int First();
        int Next();
        bool IsDone();
        int CurrentItem();
    }

    // ConcreteIterator
    public class ConcreteIterator : IIterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public int First()
        {
            return _aggregate[0];
        }

        public int Next()
        {
            int ret = 0;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
            return ret;
        }

        public int CurrentItem()
        {
            return _aggregate[_current];
        }

        public bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}