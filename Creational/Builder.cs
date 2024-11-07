namespace Creational
{
    // Product class
    public class Product
    {
        public string PartA { get; set; }
        public string PartB { get; set; }
        public string PartC { get; set; }

        public override string ToString()
        {
            return $"Product [PartA={PartA}, PartB={PartB}, PartC={PartC}]";
        }
    }

    // Builder interface
    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
        Product GetResult();
    }

    // Concrete Builder
    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public void BuildPartA()
        {
            _product.PartA = "PartA";
        }

        public void BuildPartB()
        {
            _product.PartB = "PartB";
        }

        public void BuildPartC()
        {
            _product.PartC = "PartC";
        }

        public Product GetResult()
        {
            return _product;
        }
    }

    // Director
    public class Director
    {
        private IBuilder _builder;

        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }

    // Client code
    public class BuilderClient
    {
        public static void Main(string[] args)
        {
            IBuilder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetResult();
            Console.WriteLine(product);
        }
    }
}