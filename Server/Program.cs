using System;

class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            var srv = new TcpServer();
            srv.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine("SERVER ERROR: " + ex.Message);
            Console.ReadKey();
        }
    }
}