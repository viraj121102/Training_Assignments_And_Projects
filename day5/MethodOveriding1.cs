// /*method overriding -- where some methods in base class and in inherited or child class are with the same name
// run time  binding -- when compiler will identify which method
// needs to be called at run time when the object will be created*/
// // override krne ke liye in C# hm use krte hain override + virtual keyword (virtual base class mein lagega or override child class mein.
// // kunki agr hm keywords nahi lagyenge to wo automatically pehle parent class ka method lega or child class ka method hide krdega)
using System;
public class Father
{
    public virtual void Car()
    {
        Console.WriteLine("The car no is DLCN23564");
    }
}
public class Child : Father
{
    public override void Car()
    {
        Console.WriteLine("The car no is D");
    }
}


public class MainProgram
{

    static void Main()
    {
        //Late Binding - RunTime Polymorphism
        Father p = new Child();
        p.Car();
    }
}

// // both are having the Car() method but without virtual and override keyword it's not overriding -- they just hide 

