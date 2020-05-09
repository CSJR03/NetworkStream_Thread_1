using System;
using System.IO;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        //Client

        const int Port = 8080;
        const string Address = "127.0.0.1";

        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                Console.WriteLine("Please Enter your data");
                Console.Write("Your Name: ");
                string userName = Console.ReadLine();

                Console.Write("Your cash: ");
                decimal sum = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Your period in mounth: ");
                int period =int.Parse(Console.ReadLine());

                client = new TcpClient(Address, Port);
                NetworkStream stream = client.GetStream();

                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(userName);
                writer.Write(sum);
                writer.Write(period);
                writer.Flush();

                BinaryReader reader = new BinaryReader(stream);

                string accountNumber = reader.ReadString();
                Console.WriteLine("Your Account Number: - " + accountNumber);

                reader.Close();
                writer.Close();

            }
            catch(Exception mes)
            {
                Console.WriteLine(mes.Message);
            }
            finally
            {
                client.Close();
            }
            Console.Read();
        }
    }
}
