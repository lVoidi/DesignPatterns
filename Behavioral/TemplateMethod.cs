namespace Behavioral.TemplateMethod
{
    // TemplateMethod
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
        }

        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();
    }

    // ConcreteClassA
    public class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            System.Console.WriteLine("ConcreteClassA: PrimitiveOperation1");
        }

        public override void PrimitiveOperation2()
        {
            System.Console.WriteLine("ConcreteClassA: PrimitiveOperation2");
        }
    }

    // ConcreteClassB
    public class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            System.Console.WriteLine("ConcreteClassB: PrimitiveOperation1");
        }

        public override void PrimitiveOperation2()
        {
            System.Console.WriteLine("ConcreteClassB: PrimitiveOperation2");
        }
    }

    // Client
    class TemplateMethodProgram
    {
        static void Main(string[] args)
        {
            AbstractClass classA = new ConcreteClassA();
            AbstractClass classB = new ConcreteClassB();

            classA.TemplateMethod();
            classB.TemplateMethod();
        }
    }
}