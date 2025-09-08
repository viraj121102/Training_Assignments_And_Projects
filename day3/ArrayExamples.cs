// array example
using System;
//1.

string[] cars = { "Bmw", "Audi", "Hero" };
//printing the cars
//2.
int size = 4;
int[] age = new int[size];
Console.WriteLine("Enter values:");
for (int i = 0; i < 4; i++)
{
    age[i] = Convert.ToInt32(Console.ReadLine());
}
foreach (int s in age)
{
    Console.WriteLine(s);
}

