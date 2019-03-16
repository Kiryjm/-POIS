using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Warship
{
   public class EnemyServer
   {
       private const int Port = 50000;
       private char[,] Map;
       private TcpListener server;
       private Thread serverThread;
        public EnemyServer(char[,] HomeMap)
        {
            Map = HomeMap;
            
        }

       public void serverStart()
       {
           server = new TcpListener(Port);
           serverThread = new Thread(ServerWorker);
           serverThread.Start();
       }

       private void ServerWorker()
       {
           server.Start();

           byte[] streamResponse = new byte[10];

           while (true)
           {
               Console.WriteLine("Ожидание подключений... ");

               // получаем входящее подключение
               TcpClient client = server.AcceptTcpClient();
               Console.WriteLine("Подключен клиент. Выполнение запроса...");

               // получаем сетевой поток для чтения и записи
               NetworkStream stream = client.GetStream();
               stream.Read(streamResponse, 0, 10);

               Point point;
               using (var ms = new MemoryStream(streamResponse))
               {
                   using (var r = new BinaryReader(ms))
                   {

                           point = new Point(r.ReadInt32(), r.ReadInt32());
                   }
               }

               // сообщение для отправки клиенту
               string response = Map[point.X, point.Y].ToString();
               // преобразуем сообщение в массив байтов
               byte[] data = Encoding.UTF8.GetBytes(response);

               // отправка сообщения
               stream.Write(data, 0, data.Length);
               Console.WriteLine("Отправлено сообщение: {0}", response);
               // закрываем поток
               stream.Close();
               // закрываем подключение
               client.Close();
           }
       }

   }
}
