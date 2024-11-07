using System;

namespace Structural
{
    // Subsystem 1
    class SubsystemA
    {
        public void OperationA()
        {
            Console.WriteLine("SubsystemA: OperationA");
        }
    }

    // Subsystem 2
    class SubsystemB
    {
        public void OperationB()
        {
            Console.WriteLine("SubsystemB: OperationB");
        }
    }

    // Subsystem 3
    class SubsystemC
    {
        public void OperationC()
        {
            Console.WriteLine("SubsystemC: OperationC");
        }
    }

    // Facade
    class Facade
    {
        private SubsystemA _subsystemA;
        private SubsystemB _subsystemB;
        private SubsystemC _subsystemC;

        public Facade()
        {
            _subsystemA = new SubsystemA();
            _subsystemB = new SubsystemB();
            _subsystemC = new SubsystemC();
        }

        public void Operation1()
        {
            Console.WriteLine("Facade: Operation1");
            _subsystemA.OperationA();
            _subsystemB.OperationB();
        }

        public void Operation2()
        {
            Console.WriteLine("Facade: Operation2");
            _subsystemB.OperationB();
            _subsystemC.OperationC();
        }
    }

    // Client
    class FacadeClient
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();

            facade.Operation1();
            facade.Operation2();
        }
    }
}