using System;

namespace Creational
{
    // Prototype interface
    public interface IPrototype<T>
    {
        T Clone();
    }

    // Concrete prototype
    public class ConcretePrototype : IPrototype<ConcretePrototype>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ConcretePrototype(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Implement the Clone method
        public ConcretePrototype Clone()
        {
            return (ConcretePrototype)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    // Client code
    class PrototypeClient
    {
        static void Main(string[] args)
        {
            ConcretePrototype prototype1 = new ConcretePrototype(1, "Prototype 1");
            ConcretePrototype clone1 = prototype1.Clone();

            Console.WriteLine("Original: " + prototype1);
            Console.WriteLine("Clone: " + clone1);
        }
    }
}