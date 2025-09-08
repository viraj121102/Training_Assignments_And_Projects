using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MathLibrary_Testing_using_Nunit
{
    public class Calculator
    {
        public int Add(int x, int y)
        {
            return x + y;   
        }

        // Lambda expression for subtraction
        public int sub(int x, int y) => x - y;

        public int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
