using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NetworkStream_Thread_1
{
    //server
    class Program
    {
        const int Port = 8080;
        static TcpListener listener;

        static void Main(string[] args)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), Port);
                listener.Start();

                Console.WriteLine("Server is Run ...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);

                    Task clientTask = new Task(clientObject.Procces);
                    clientTask.Start();




                }

            }
            catch(Exception mes)
            {
                Console.WriteLine(mes.Message);
            }
            finally
            {
                if(listener != null)
                {
                    listener.Stop();
                }
            }

        }
    }
}
