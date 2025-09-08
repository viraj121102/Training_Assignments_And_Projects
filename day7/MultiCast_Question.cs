
// // create a delegate for a admin who is responsible for calculating the invoice(int tutionfess , int transportfees)
// //and one more delegate which will print the invoice
// // now create two print methods one for printing (Page1 )the actual invoice and second print method (page 2) for deduction of 100% from tution fees
// using System;
// class Multi
// {
//     // delegate decleration 
//     public delegate int Admin(int tFees, int tpFees);

//     public delegate void PrintData(int total);

//     static void Main()
//     {
//         // assigning methods to delegate
//         Admin ad = TotalFess;
//         PrintData p = Show;// for first page
//         p += show1;// for second page
//         int res = ad(10000, 2000);
//         p(res);

//     }

//     public static int TotalFess(int tf, int tpf)
//     {
//         int gst = 10;
//         return gst + tf + tpf;

//     }
//     public static void Show(int total)
//     {
//         Console.WriteLine("the total fees is:" + total);
//     }
//     public static void show1(int total)
//     {
//         Console.WriteLine(" You are the special student so you get scholarship and you do not have pay:");
//      }       

// }