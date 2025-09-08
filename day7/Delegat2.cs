// class ABC {

//     // Delegate Declaration for add operations and Print 
//     // parameterized Delegates responsible for method invocation at runtime
//     public delegate int AddDelegate(int a, int b);

//     public delegate void PrintDelegate(int result);

//     public static void Main(string[] args) {

//         //Assign Methods to delegates
//         AddDelegate addDelegate = AddNumbers;

//         /*int a ;
//         // a =30;
//         ABC a1 = new ABC();
//         AddDelegate ad = AddNumbers;*/

//         PrintDelegate print = PrintResult;

//         // calling/using delegate
//        int sum = addDelegate(10, 30);
//         print(sum);

//     }


//     static int AddNumbers(int x , int y)
//     { return x + y; }

//     static void PrintResult(int result)
//     { 
//         Console.WriteLine(result);
//     }
// }


