    //   //Tuples & Deconstruction

    //     // : a tuple is a light weight data container but on the other side it
    //     // also unpacks(deconstruct) into variables

    // class Abc
    // {
    //     //(int min , int max) -- Return type : Tuple with named fields  ---
    //     // GetMinMax   // Method name
    //     //(int[] arr)   // Input parameter : array of integers


    //     public static (int min, int max) GetMinMax(int[] arr)
    //         {

    //         //Min() and Max() are LINQ methods which comes under using System.LINQ 
    //         return (arr.Min(), arr.Max());
        
    //     }
        
        
    //     }

    // class ProgramExample
    // {
    //     static void Main(string[] args) {
    //         //deconstruction back to tuple
    //         var (min, max) =  Abc.GetMinMax(new[] { 4, 5, 6, 1 });
    //         Console.WriteLine("Min"+ min + "Max" +  max);
    //     }
    // }