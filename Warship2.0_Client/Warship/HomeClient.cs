using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Warship
{
    public class HomeClient
    {
        private const int port = 50000;
        private const string server = "127.0.0.1";
        private TcpClient client;
        private Message message;

        public HomeClient()
        {
            client = new TcpClient();
        }

        private byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public Message SendAndGetAnswer (Message message)
        {
            if (!client.Connected)
            {
                client.Connect(server, port);
            }

           
            NetworkStream stream = client.GetStream();
            byte[] data;
            IFormatter formatter = new BinaryFormatter();

            data = ObjectToByteArray(message);
            stream.Write(data, 0, data.Length);
            Message receivedMessage = (Message)formatter.Deserialize(stream);

            return receivedMessage;
        }

    }
}
