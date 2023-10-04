using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

string message = "00000****000000000000000000000000****000000000000000000000000000000000000000000000000000000000000000";

TcpClient player = new TcpClient();
Console.WriteLine("Клиент создан");

player.Connect(IPEndPoint.Parse("127.0.0.1:30297"));
Console.WriteLine("Подключение успешно");
NetworkStream stream = player.GetStream();

StreamReader reader = new StreamReader(stream);
StreamWriter writer = new StreamWriter(stream);
writer.WriteLine(message);
writer.Flush();

Console.WriteLine("Данные ушли");

//StringBuilder fields = new StringBuilder();

var my_field = reader.ReadLine();
var enemy_field = reader.ReadLine();

//StringBuilder final_view = new StringBuilder();

for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(my_field.Substring(i * 10, 10) + "\t\t" + enemy_field.Substring(i * 10, 10));
}


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
    for (int i = 0; i < 10; ++i)
    {
        Console.WriteLine(my_field.Substring(i * 10, 10) + "\t\t" + enemy_field.Substring(i * 10, 10));
    }

    my_field = reader.ReadLine();
    enemy_field = reader.ReadLine();
    Console.Clear();

    for (int i = 0; i < 10; ++i)
    {
        Console.WriteLine(my_field.Substring(i * 10, 10) + "\t\t" + enemy_field.Substring(i * 10, 10));
    }
}


Console.ReadLine();