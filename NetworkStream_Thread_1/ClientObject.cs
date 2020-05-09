using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStream_Thread_1
{
    public class ClientObject
    {
        public TcpClient client;
        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public void Procces()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);

                string name = reader.ReadString();
                decimal sum = reader.ReadDecimal();
                int period = reader.ReadInt32();

                Account account = new Account(name, sum, period);

                Console.WriteLine(account.Name + " Open Safe Account Number: Cash - " + account.Sum);

                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(account.Id);
                writer.Flush();

                writer.Close();
                reader.Close();

            }
            catch(Exception mes)
            {
                Console.WriteLine(mes.Message);
            }
            finally
            {
                if(stream != null)
                {
                    stream.Close();
                }
                if(client != null)
                {
                    client.Close();
                }
            }

        }
    }
}
