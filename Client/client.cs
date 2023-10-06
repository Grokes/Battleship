using System.IO;
using System.Net;
using BattleShip.Core.Server;
using BattleShip.ConsoleGraphic;
using System.Net.Sockets;
using System.Text;

Client player = new Client();

Console.WriteLine("Данные ушли");

player.GetData();

Draw.Print(player.my_field, player.enemy_field);


while (!player.Is_end_game)
{
    if (player.Is_your_move)
    {
        Console.WriteLine("Координаты x: ");
        string x = Console.ReadLine();
        Console.WriteLine("Координаты y: ");
        string y = Console.ReadLine();
        player.Shoot(int.Parse(x), int.Parse(y));

        Console.Clear();
        player.GetData();
        Draw.Print(player.my_field, player.enemy_field);
    }
    else 
    {
        Console.WriteLine("Ход противника");
        player.GetData();
        Console.Clear();
        Draw.Print(player.my_field, player.enemy_field);
    }
}

if (player.IsYouWin())
    Console.WriteLine("Победа");
else
    Console.WriteLine("Поражение");

Console.ReadLine();