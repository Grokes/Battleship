using BattleShip.Core;
using System.Net;
using System.Net.Sockets;

TcpListener server = new TcpListener(IPEndPoint.Parse("127.0.0.1:30297"));
Console.WriteLine("Сервер создан");
server.Start();
Console.WriteLine("Сервер запущен");
Console.WriteLine(server.LocalEndpoint);


{
    // Подключаем пользователя 1
    using TcpClient player1 = server.AcceptTcpClient();
    // Получаем потоки
    NetworkStream streamP1 = player1.GetStream();
    StreamReader readerP1 = new StreamReader(streamP1);
    StreamWriter writerP1 = new StreamWriter(streamP1);
    // Принимаем поле
    string? fieldTextP1 = readerP1.ReadLine();
    // Генерируем поле
    GameField fieldP1 = new GameField(fieldTextP1);
    Console.WriteLine("1 подключение успешно");

    //Аналогично
    using TcpClient player2 = server.AcceptTcpClient();

    NetworkStream streamP2 = player2.GetStream();
    StreamReader readerP2 = new StreamReader(streamP2);
    StreamWriter writerP2 = new StreamWriter(streamP2);

    string fieldTextP2 = readerP2.ReadLine();
    GameField fieldP2 = new GameField(fieldTextP2);

    Console.WriteLine("2 подключение успешно");

    // Формируем строку поля и отправляем клиентам
    fieldTextP1 = fieldP1.PrintField();
    Console.WriteLine(fieldTextP1);
    fieldTextP2 = fieldP2.PrintField();
    Console.WriteLine(fieldTextP2);

    writerP1.Write(fieldTextP1);
    writerP1.Write(fieldTextP2);
    writerP1.Flush();

    writerP2.Write(fieldTextP1);
    writerP2.Write(fieldTextP2);
    writerP2.Flush();

    // Запрашиваем координаты и стреляем
    int x = int.Parse(readerP1.ReadLine());
    int y = int.Parse(readerP1.ReadLine());

    fieldP2.Shoot(x,y);

    // Формируем строку поля и отправляем клиентам
    fieldTextP1 = fieldP1.PrintField();
    fieldTextP2 = fieldP2.PrintField();

    writerP1.Write(fieldTextP1);
    writerP1.Write(fieldTextP2);
    writerP1.Flush();

    writerP2.Write(fieldTextP1);
    writerP2.Write(fieldTextP2);
    writerP2.Flush();


    Console.ReadLine();
}

public class GameClass
{
    TcpListener server;
    Player player1;
    Player player2;

}

public class Player
{
    GameField field;
    TcpClient player;
    StreamReader reader;
    StreamWriter writer;
}