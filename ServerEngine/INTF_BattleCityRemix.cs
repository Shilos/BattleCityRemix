using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerEngine
{
	//заглушка
	public interface IProtocol
	{
	}
	public delegate void ProcessMessageHandler(IEnumerable<IProtocol> list);
	public interface IServerEngine
	{
		ProcessMessageHandler ProcessMessage { get; }
		IProtocol GenerateMap();
		IProtocol Reload(int id);
		IProtocol Move(int id);
		IProtocol Fire(int id);
		IProtocol Death(int id);
		// тут логично принимать какое-то условие для определения победы из IRoom
		IProtocol CheckWin();
		IEnumerable<IProtocol> Send();
	}
}
