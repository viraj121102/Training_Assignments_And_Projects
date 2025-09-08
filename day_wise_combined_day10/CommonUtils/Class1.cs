using System;

namespace CommonUtils
{
    // 1. Custom delegate (for comparison with built-in)
    public delegate void MyDel(int x);

    public class MyClass
    {
        int x = 10;
        MyGenericClass<int> obj = new MyGenericClass<int>();

        // A regular method
        public void Square(int y)
        {
            Console.WriteLine("Square (Named method): " + (y * y));
        }

        public void MyMethod()
        {
            obj.MyMethod(x); // Call generic method

            Console.WriteLine("\n--- Custom Delegates ---");
            // 2. Custom delegate to named method
            MyDel del1 = Square;
            del1(5);

            // 3. Anonymous method using delegate
            MyDel del2 = delegate (int z)
            {
                Console.WriteLine("Square (Anonymous): " + (z * z));
            };
            del2(6);

            // 4. Lambda using custom delegate
            MyDel del3 = (int a) => Console.WriteLine("Square (Lambda): " + (a * a));
            del3(7);

            Console.WriteLine("\n--- Built-in Delegates ---");

            // 5. Action<T>: like void(int)
            Action<int> printDouble = (n) => Console.WriteLine("Double: " + (n * 2));
            printDouble(10);

            // 6. Func<TInput, TResult>: like int -> string
            Func<int, string> evenOdd = (num) =>
            {
                return num % 2 == 0 ? "Even" : "Odd";
            };
            Console.WriteLine("Func Result: " + evenOdd(13));  // Output: Odd

            // 7. Predicate<T>: returns bool
            Predicate<string> isLongString = (str) => str.Length > 5;
            Console.WriteLine("Is 'hello' a long string? " + isLongString("hello"));  // Output: False
            Console.WriteLine("Is 'delegate' a long string? " + isLongString("delegate"));  // Output: True
        }
    }

    public class MyGenericClass<T>
    {
        public void MyMethod(T value)
        {
            if (value.GetType() == typeof(string))
            {
                Console.WriteLine("Send an email");
            }
            else if (value.GetType() == typeof(int))
            {
                Console.WriteLine("Send a SMS");
            }
            else
            {
                Console.WriteLine("Unsupported type");
            }
        }
    }
}
