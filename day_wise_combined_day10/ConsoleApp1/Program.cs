using ConsoleApp1;

ThreadingExample obj = new ThreadingExample();

//obj.Even();
//obj.Odd();

//when multiple things need to be execute simultaneously then we should use threading
Thread T1 = new Thread(obj.Even);
Thread T2 = new Thread(obj.Odd);
T1.Start();
Thread.Sleep(5000);
T1.Join();
T2.Start();
Console.ReadLine();