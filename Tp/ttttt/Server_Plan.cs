using System.Collections.Generic;
using System.Net.Sockets;

namespace Plan
{
	interface IServer
	{
		short Port { get; set; }
		IHostListen hostListen { get; set; }
		IEnumerable<IRoom> rooms { get; set; }
		void Send_Room_List();
	}

	interface IRoom
	{
		IMesegeQueue mesegeQueue { get; set; }
		IEngine engine { get; set; }
		ISender sender { get; set; }
		IEnumerable<IGamer> gamer { get; set; }
		IroomStat roomStat { get; set; }
	}

	interface IGamer
	{
		IGamerStat gamerStat { get; set; }
		UdpClient client { get; set; }
	}

	interface IEngine
	{
		//обработка полета пули
		//отправка координат всех обьектов каждому игроку
		//обработка события убийства
		//начало игры
		//конец игры
	}

	interface IHostListen { }
}
