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



    [Serializable]
    public class Message
    {

        public MessageType MessageType { get; set; }
        private int processId;
        private Point point;
        private int turn;


        public char PointValue
        {
            get;
            set;
        }

        public Message()
        {
        }

        public Message(int processId, MessageType messageType)
        {
            this.ProcessId = processId;
            this.MessageType = messageType;
        }

        public Message(Point point, MessageType messageType)
        {
            this.Point = point;
            this.MessageType = messageType;
        }

        public Message(int processId, Point point, int turn)
        {
            this.ProcessId = processId;
            this.Point = point;
            this.Turn = turn;

        }

        public Message(Point point, int turn)
        {
            this.Point = point;
            this.Turn = turn;

        }

        public Message(int processId, int turn)
        {
            this.ProcessId = processId;
            this.Turn = turn;

        }


        public Message(int processId)
        {
            this.ProcessId = processId;

        }

        public Message(Point point)
        {
            this.Point = point;

        }

        public int ProcessId
        {
            get { return processId; }
            set { processId = value; }
        }

        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        public int Turn
        {
            get { return turn; }
            set { turn = value; }
        }
    }
}
