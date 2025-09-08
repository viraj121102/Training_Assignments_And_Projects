class LoopProgram {
    static void Main(){ 
        

        // syntax of for loop 
        //  initialization, condition, increment
        Console.WriteLine("For Loop");
        for(int i = 0; i <= 5; i++){
            Console.WriteLine($"The value of i is: {i}");
        }


        // while loop
        Console.WriteLine("While Loop");
        int x = 0; 
        while(x < 5) {
            Console.WriteLine($"The value of x is: {x}");
            x++;
        }

        // do while loop
        Console.WriteLine("Do while Loop");
        int y = 0; 
        do {
            // even if the condition fail program will execute once
            Console.WriteLine($"The value of y is: {y}");
            y++;
        }
        while(y < 1);

        // To use for each loop in case of arrays / collection
        string[] names = {"Nitesh", "Nitin", "Aman"};
        Console.WriteLine("The element at first index no:" + names[0]);
        foreach(string name in names){
            Console.WriteLine(name);
        }
    }
}

// Single dimensional array
// Array is fixed size
// int[] numbers = new int[5];
// int[] scores = {45, 67, 34, 67,43}
// Array is good/fast in searching

// Multidimensional Array
// int[,] matrix = new int[2,3]
// {
//     {3,4,5},
//     {7,8,3}
// }

// matrix[0,1]

// for(int i = 0 ; i < 2 ; i++){
//     for (int j = 0; j <3; j++){
//         Console.WriteLine(matrix[i][j]);
//     }
// }
