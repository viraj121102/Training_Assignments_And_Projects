using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Repos
{
    // Generic class example
    public class Patient<T>
    {
        //public void Communicate(Int64? mobile, string? email)
        //{

        //}
        public void Communicate(T input)
        {
            if (input.GetType() == typeof(string))
            {
                // send email
            }
            else if (input.GetType() == typeof(Int64))
            {
                // send sms
            }
            else
            {
                throw new FormatException();
            }
        }
    }

    public class PatientForm
    {
        Patient<int> p = new Patient<int>();

        public void Test()
        {
            p.Communicate(1234567890);

        }

        Patient<string> p2 = new Patient<string>();

        public void Test2()
        {
            p2.Communicate("hheiwuh");

        }

        //Patient p3 = new Patient();

        //public void Test3()
        //{
        //    p3.Communicate<string>("hheiwuh");

        //}
    }
}
