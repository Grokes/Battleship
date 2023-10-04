using BattleShip.Core;
using System.Net;
using BattleShip.Core.Server;
using System.Net.Sockets;

GameRoom room = new GameRoom();
room.Start();
room.AcceptPlayer();

room.SendDataClients();

while (true)
{
    room.Player1.Shoot(room.Player2);
    room.SendDataClients();
    room.Player2.Shoot(room.Player1);
    room.SendDataClients();
}
/*
Разделение по библиотекам
#1
BattleShip.Core.Server
GameRoom
PlayerServer
PlayerClient...
     
#2
BattleShip.Server
GameRoom
PlayerServer

BattleShip.Client
PlayerClient...     

Оставлять ли Core
Название Server or NetworkMode

*/


Console.ReadLine();
