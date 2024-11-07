namespace Structural.Module
{
    class ModuleProgram
    {
        static void Main(string[] args)
        {
            int result1 = MathModule.Sum(5, 3);
            Console.WriteLine($"5 + 3 = {result1}");

            int result2 = MathModule.Subtract(10, 4);
            Console.WriteLine($"10 - 4 = {result2}");

            int result3 = MathModule.Multiply(7, 6);
            Console.WriteLine($"7 * 6 = {result3}");

            int result4 = MathModule.Divide(20, 5);
            Console.WriteLine($"20 / 5 = {result4}");
}
    }
}