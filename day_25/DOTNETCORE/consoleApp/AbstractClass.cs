using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleApp
{
    // Interface are 100% abstract
    public interface I1
    {
        // only methods are allowed and no implementation
        void myMethod(); // interface method (does not have a body)

        void CreateBooking();
        void cancelBooking();

    }

    // Abstract class
    public abstract class V1
    {
        // Abstract method (does not have a body)
        public abstract void myMethod();

        // Regular method
        public void myNonAbstractMethod()
        {
            Console.WriteLine("This is a non-abstract method in the abstract class.");
        }

    }

    public class V2: V1, I1
    {
        public override void myMethod()
        {
            Console.WriteLine("Implementation of the abstract method in the derived class.");
        }

        void I1.cancelBooking()
        {
            throw new NotImplementedException();
        }

        void I1.CreateBooking()
        {
            throw new NotImplementedException();
        }

        void I1.myMethod()
        {
            throw new NotImplementedException();
        }
    }
}
