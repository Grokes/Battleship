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
        public bool Is_your_move { get; set; }
        public bool Is_end_game { get; set; }
        StreamReader reader;
        StreamWriter writer;
        BinaryReader readerBin;
        public string my_field;
        public string enemy_field;



        public Client()
        { 
            player = new TcpClient();
            my_field = "*000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            player.Connect(IPEndPoint.Parse("94.19.144.216:30297"));
            NetworkStream stream = player.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            readerBin = new BinaryReader(stream);
            writer.WriteLine(my_field);
            writer.Flush();
        }
        //public void Connect()
        //{
        //    player.Connect(IPEndPoint.Parse("127.0.0.1:30297"));
        //    writer.WriteLine(my_field);
        //    writer.Flush();
        //}

        public void Shoot(int x, int y)
        {
            writer.WriteLine(x);
            writer.Flush(); 
            writer.WriteLine(y);
            writer.Flush();
        }
        public void GetData()
        {
            Is_your_move = readerBin.ReadBoolean();
            Is_end_game = readerBin.ReadBoolean();
            my_field = reader.ReadLine();
            enemy_field = reader.ReadLine();
        }
        public bool IsYouWin()
        {
            return my_field.Contains('■');
        }
    }
}
