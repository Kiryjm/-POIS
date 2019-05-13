using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Warship
{
   public class EnemyServer
   {
       private const int Port = 50001;
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

       private void ServerWorker()
       {
           server.Start();

           byte[] data;
           while (true)
           {
               Console.WriteLine("Ожидание подключений... ");

               // получаем входящее подключение
               TcpClient client = server.AcceptTcpClient();
               Console.WriteLine("Подключен клиент. Выполнение запроса...");

               // получаем сетевой поток для чтения и записи
               NetworkStream stream = client.GetStream();
               
               IFormatter formatter = new BinaryFormatter();

               Message receivedMessage = (Message)formatter.Deserialize(stream);
               Message response = new Message();

               
               //switch ((int)receivedMessage.MessageType)
               //{
               //    case 1 : response.ProcessId = receivedMessage.ProcessId;
               //        break;

               //    case 2: response.PointValue = Map[receivedMessage.Point.X, receivedMessage.Point.Y];
               //        break;

               //    case 3: response.Turn = receivedMessage.Turn;
               //        break;

               //}
               response.PointValue = Map[receivedMessage.Point.X, receivedMessage.Point.Y];
               
               // сообщение для отправки клиенту
           
               // преобразуем сообщение в массив байтов
               data = ObjectToByteArray(response);

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
