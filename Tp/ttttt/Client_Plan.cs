using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Plan
{
	interface IGameClient
	{
		IPAddress server_ip { get; set; }
		short server_port { get; set; }
		UdpClient udpClient { get; set; }

		IEnumerable<IroomStat> rooms_online { get; set; }
		IEngineClient engineClient { get; set; }
		ISender sender { get; set; }
		IMesegeQueue mesegeQueue { get; set; }
		bool Connect_to_Server();
	}

	interface IEngineClient
	{
		IEnumerable<IGamerStat> players { get; set; }
	}
}
