using System.IO;
using System.Net;
using BattleShip.Core.Server;
using BattleShip.ConsoleGraphic;
using System.Net.Sockets;
using System.Text;

//string message = "00000****000000000000000000000000****000000000000000000000000000000000000000000000000000000000000000";

//TcpClient player = new TcpClient();
//Console.WriteLine("Клиент создан");
Client player = new Client();
player.Connect();
//player.Connect(IPEndPoint.Parse("127.0.0.1:30297"));
//Console.WriteLine("Подключение успешно");
//NetworkStream stream = player.GetStream();

//StreamReader reader = new StreamReader(stream);
//StreamWriter writer = new StreamWriter(stream);
//writer.WriteLine(message);
//writer.Flush();

Console.WriteLine("Данные ушли");

//var my_field = reader.ReadLine();
//var enemy_field = reader.ReadLine();

player.GetData();

Draw.Print(player.my_field, player.enemy_field);


while (true)
{
    Console.WriteLine("Координаты x: ");
    string x = Console.ReadLine();
    Console.WriteLine("Координаты y: ");
    string y = Console.ReadLine();
    writer.WriteLine(x);
    writer.Flush();
    writer.WriteLine(y);
    writer.Flush();
    Console.Clear();

    my_field = reader.ReadLine();
    enemy_field = reader.ReadLine();


    Draw.Print(my_field, enemy_field);

    my_field = reader.ReadLine();
    enemy_field = reader.ReadLine();
    Console.Clear();

    Draw.Print(my_field, enemy_field);
}


Console.ReadLine();