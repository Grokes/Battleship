using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BattleShip.Core.Server
{
    public class Client
    {
        TcpClient player;
        StreamReader reader;
        StreamWriter writer;
        public string my_field;
        public string enemy_field;


        public Client()
        { 
            player = new TcpClient();
            NetworkStream stream = player.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            my_field = "00000****000000000000000000000000****000000000000000000000000000000000000000000000000000000000000000";
        }
        public void Connect()
        {
            player.Connect(IPEndPoint.Parse("127.0.0.1:30297"));
            writer.WriteLine(my_field);
            writer.Flush();
        }

        public void Shoot(int x, int y)
        {
            writer.WriteLine(x);
            writer.Flush(); 
            writer.WriteLine(y);
            writer.Flush();
        }
        public void GetData()
        {
            my_field = reader.ReadLine();
            enemy_field = reader.ReadLine();
        }
    }
}
