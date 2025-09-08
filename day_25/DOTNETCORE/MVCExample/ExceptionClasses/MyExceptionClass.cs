namespace MVCExample.ExceptionClasses
{
    public class MyExceptionClass:Exception
    {
        string msg;
        public MyExceptionClass(string message): base(message)
        {
            msg = message;
        }

        public void MyException()
        {
            throw new Exception(msg);
        }
    }
}
