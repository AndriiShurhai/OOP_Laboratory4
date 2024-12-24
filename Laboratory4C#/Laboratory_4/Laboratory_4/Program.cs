using System;

namespace Laboratory_4
{
    class Program
    {
        static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
                                   // I’m not sure how to create constant factor "2" in more elegant way,
                                   // without knowing how IMyNumber is implemented
            Console.WriteLine("2*a*b = " + curr);


            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }

        static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a^2-b^2)/(a+b)=(a-b) with a = " + a + ", b = " + b + " ===");

            // Calculate a^2-b^2
            T aSquare = a.Multiply(a);
            T bSquare = b.Multiply(b);
            T diffSquares = aSquare.Substruct(bSquare);
            Console.WriteLine("a^2 = " + aSquare);
            Console.WriteLine("b^2 = " + bSquare);
            Console.WriteLine("a^2-b^2 = " + diffSquares);

            // Calculate a+b
            T sum = a.Add(b);
            Console.WriteLine("a+b = " + sum);

            // Calculate (a^2-b^2)/(a+b)
            try
            {
                T leftPart = diffSquares.Divide(sum);
                Console.WriteLine("(a^2-b^2)/(a+b) = " + leftPart);

                // Calculate a-b for comparison
                T rightPart = a.Substruct(b);
                Console.WriteLine("a-b = " + rightPart);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Division by zero detected: " + e.Message);
            }

            Console.WriteLine("=== Finishing testing (a^2-b^2)/(a+b)=(a-b) with a = " + a + ", b = " + b + " ===");
        }

        static void Main(string[] args)
        {
            testAPlusBSquare(new Frac(1, 3), new Frac(1, 6));
            Console.WriteLine();
            Console.WriteLine();
            testAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

            Console.WriteLine();
            Console.WriteLine();

            testSquaresDifference(new Frac(1, 3), new Frac(1, 6));

            Console.WriteLine();
            Console.WriteLine();

            testSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\nTesting division by zero:");
            testSquaresDifference(new Frac(1, 2), new Frac(-1, 2)); // a+b = 0
            Console.WriteLine();
            Console.WriteLine();
            testSquaresDifference(new MyComplex(1, 0), new MyComplex(-1, 0)); // a+b = 0

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Sort array of Fracs: [1/2, 5/6, 1/1, 3/4, 4/5]");
            Frac[] fracs = { new Frac(1, 2), new Frac(5, 6), new Frac(1, 1), new Frac(3, 4), new Frac(4, 5) };
            Array.Sort(fracs);
            
            foreach (var f in fracs)
            {
                Console.Write($"{f}    ");
            }

            Console.ReadKey();
        }
    }
}