using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_W_Mod3_4_Delegates
{
    internal class Sum
    {
        private static event Func<double, double, double> PlusHandler;
        public static void Execute()
        {
            TryCatch(MultiCast);
        }

        private static double Calculates(double x, double y)
        {
            double z = x + y;

            return z;
        }

        private static void TryCatch(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                Console.WriteLine("Something gone wrong!");
            }
        }

        private static void MultiCast()
        {
            PlusHandler += Calculates;
            PlusHandler += Calculates;
            Delegate[] delegates = PlusHandler.GetInvocationList();
            double res = 0;
            foreach (Delegate delegator in delegates)
            {
                Console.WriteLine(" Enter number for Summation");
                string sX = Console.ReadLine();
                double x1 = Convert.ToDouble(sX);
                Console.WriteLine(" Enter number for Summation");
                string sY = Console.ReadLine();
                double y1 = Convert.ToDouble(sY);
                Func<double, double, double> func1 = (double x, double y) => (double) delegator.DynamicInvoke(x, y);
                res += func1(x1, y1);
                Console.WriteLine($"{x1} + {y1} = {x1 + y1}");
            }

            Console.WriteLine($"Result of multi summation is {res}");
        }
    }
}
