using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Warship
{
    public class HomeClient
    {
        private const int port = 50001;
        private const string server = "127.0.0.1";
        private TcpClient client;

        public HomeClient()
        {
            client = new TcpClient();
        }

        public string pointSend(Point point)
        {
            client.Connect(server,port);
            NetworkStream stream = client.GetStream();
            StringBuilder response = new StringBuilder();

            byte[] data;
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                        bw.Write(point.X);
                        bw.Write(point.Y);

                }
                data = ms.ToArray();
            }
            stream.Write(data, 0, data.Length);
            do
            {
                int bytes = stream.Read(data, 0, data.Length);
                response.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            return response.ToString();
        }
    }
}
