// using System;
// class ABC
// {

//     // Delegate Declaration for add operations and Print 
//     // parameterized Delegates responsible for method invocation at runtime
//     public delegate int Operations(int a, int b);

//     public delegate void PrintDelegate(int result);

//     public static void Main(string[] args)
//     {

//         //Assign Methods to delegates
//         //Member functions are encapsulated using delegate
//         Operations Add = AddNumbers;
//         Operations Subtract = SubtractNumbers;
//         /*int a ;
//         // a =30;
//         ABC a1 = new ABC();
//         AddDelegate ad = AddNumbers;*/

//         PrintDelegate print = PrintResult;

//         // calling/using delegate
//         int result1 = Add(10, 30);
//         int result2 = Subtract(10, 30);
//         Console.WriteLine("Enter your choice 1. for Addition and 2. for subtraction");
//         int choice = int.Parse(Console.ReadLine());


//         switch (choice)
//         {
//             case 1:
//                 print(result1);
//                 break;
//             case 2:
//                 print(result2);
//                 break;
//         }

//     }


//     private static int AddNumbers(int x, int y)
//     { return x + y; }

//     private static int SubtractNumbers(int x, int y)
//     { return x - y; }

//     private static void PrintResult(int result)
//     {
//         Console.WriteLine("The result is :" + result);
//     }
// }

