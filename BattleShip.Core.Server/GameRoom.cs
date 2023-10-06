using System.Net;
using System.Net.Sockets;

namespace BattleShip.Core.Server
{
    public class GameRoom
    {
        TcpListener server;
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        public GameRoom()
        {
            server = new TcpListener(IPEndPoint.Parse("192.168.1.211:30297"));  
        }
        public void Start()
        {
            server.Start();
        }
        public void AcceptPlayer() //Обратить внимание на получение игрового поля
        {
            Player1 = new Player(server.AcceptTcpClient());
            Player1.RequestField();
            Player1.Is_your_move = true;
            Player2 = new Player(server.AcceptTcpClient());
            Player2.RequestField();
            Player2.Is_your_move = false;
        }
        public void SendDataClients() //Разместить переменные в полях класса, переопределить методы Write\Flush
        {
            var fieldP1 = Player1.GetFieldData();
            var fieldHiddenP1 = Player1.GetFieldDataHidden();
            var fieldP2 = Player2.GetFieldData();
            var fieldHiddenP2 = Player2.GetFieldDataHidden();
            var Win = Player1.field.IsWin() || Player2.field.IsWin();

            Player1.WriterBin.Write(Player1.Is_your_move);
            Player1.WriterBin.Write(Win);
            Player1.Writer.Write(fieldP1);
            Player1.Writer.Write(fieldHiddenP2);
            Player1.Writer.Flush();

            Player2.WriterBin.Write(Player2.Is_your_move);
            Player2.WriterBin.Write(Win);
            Player2.Writer.Write(fieldP2);
            Player2.Writer.Write(fieldHiddenP1);
            Player2.Writer.Flush();
        }

        public void Stop()
        {
            server.Stop();
        }
        ~GameRoom() => Stop();
    }
}