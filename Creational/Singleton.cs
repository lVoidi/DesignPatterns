namespace Creational
{
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        // Private constructor ensures that an object is not instantiated from outside the class.
        private Singleton() 
        {
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Singleton instance is working.");
        }
    }

    class SingletonClient
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.Instance;
            singleton.DoSomething();
        }
    }
}