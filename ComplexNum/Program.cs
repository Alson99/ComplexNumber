using System;

namespace ComplexNum
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex z1 = new Complex(-2, 3);
            Console.WriteLine(z1);
            Complex z2 = new Complex(5, -1);
            Console.WriteLine(z2);
            Console.WriteLine(z2.Plus(z1));
            Console.WriteLine(z2.Times(z1));
            Console.WriteLine(z1.Div(z2));
            Console.WriteLine(z1.Div(0));

        }
    }
}
