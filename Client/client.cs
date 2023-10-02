using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

string message = "00000****000000000000000000000000****000000000000000000000000000000000000000000000000000000000000000";

TcpClient player = new TcpClient();
Console.WriteLine("Клиент создан");

player.Connect(IPEndPoint.Parse("94.19.144.216:30297"));
Console.WriteLine("Подключение успешно");
NetworkStream stream = player.GetStream();

StreamReader reader = new StreamReader(stream);
StreamWriter writer = new StreamWriter(stream);
writer.WriteLine(message);
writer.Flush();

Console.WriteLine("Данные ушли");

//StringBuilder fields = new StringBuilder();

for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(reader.ReadLine());
}
for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(reader.ReadLine());
}







Console.WriteLine("Координаты x: ");
string x = Console.ReadLine();
Console.WriteLine("Координаты y: ");
string y = Console.ReadLine();
writer.WriteLine(x);
writer.Flush();
writer.WriteLine(y);
writer.Flush();

Console.ReadLine();