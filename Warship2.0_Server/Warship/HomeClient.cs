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

        
        //public string pointSend(Point point)
        //{
        //    client.Connect(server,port);
        //    NetworkStream stream = client.GetStream();
        //    StringBuilder response = new StringBuilder();
        //    byte[] data;

        //    using (var ms = new MemoryStream())
        //    {
        //        using (var bw = new BinaryWriter(ms))
        //        {
        //                bw.Write(point.X);
        //                bw.Write(point.Y);

        //        }
        //        data = ms.ToArray();
                
        //    }

        //    stream.Write(data, 0, data.Length);
        //    do
        //    {
        //        int bytes = stream.Read(data, 0, data.Length);
        //        response.Append(Encoding.UTF8.GetString(data, 0, bytes));
        //    }
        //    while (stream.DataAvailable);

        //    return response.ToString();
        //}
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
            client.Connect(server, port);
            NetworkStream stream = client.GetStream();
            byte[] data;
            IFormatter formatter = new BinaryFormatter();

            data = ObjectToByteArray(message);
            stream.Write(data, 0, data.Length);
            Message receivedMessage = (Message)formatter.Deserialize(stream);

            return receivedMessage;
        }


        //public Message turnSend(Message message)
        //{
        //    PlayerTurnSender playerTurnSender = new PlayerTurnSender();
        //    NetworkStream stream = client.GetStream();
        //    StringBuilder response = new StringBuilder();
        //    byte[] data;

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var binaryWriter = new BinaryWriter(memoryStream))
        //        {
        //            binaryWriter.Write(message.Turn);
        //        }

        //        data = memoryStream.ToArray();
        //    }

        //    stream.Write(data, 0, data.Length);
        //        do
        //        {
        //            int bytes = stream.Read(data, 0, data.Length);
        //            response.Append(Encoding.UTF8.GetString(data, 0, bytes));

        //        }
                
        //        while (stream.DataAvailable);

        //        return message;
        //    }

    }
}
