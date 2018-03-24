using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ServerEngine
{
	public class ServerEngine : IServerEngine
	{
		public ProcessMessageHandler ProcessMessage { get; }
		private IRoom _room;
		private IList<IProtocol> processList = new List<IProtocol>();
		private List<IEntity> objects;
		public ServerEngine(IRoom room)
		{
			this.ProcessMessage = MessageHandler;
			this._room = room;
		}

		public IProtocol CheckWin()
		{
			throw new NotImplementedException();
		}
		private void MessageHandler(IEnumerable<IProtocol> list)
		{
			processList = new List<IProtocol>();
			foreach(var t in list)
			{
				
			}
		}

		public IProtocol Death(int id)
		{
			throw new NotImplementedException();
		}

		public IProtocol Fire(int id)
		{
			throw new NotImplementedException();
		}

		public IProtocol GenerateMap()
		{
			objects = new List<IEntity>();
			int colIndMin = 0;
			int colIndMax = 20;
			int rowIndMin = 0;
			int rowIndMax = 20;
			int decorCount = 10;
			int players = _room.gamerList.Count();
			while(players>0&&decorCount>0)
			{
				Random colInd = new Random(DateTime.Now.Millisecond - 15);
				Random rowInd = new Random(DateTime.Now.Millisecond + 20);
				int columnIndex = colInd.Next(colIndMin, colIndMax);
				int rowIndex = rowInd.Next(rowIndMin, rowIndMax);
				bool state = false;
				foreach(var z in objects)
				{
					if(z.Position==new Point(columnIndex,rowIndex))
					{
						state =true;
					}
				}
				if(!state)
				{
					// ???
				}
			}

			var x = objects as IProtocol;
			return x;
		}

		public IProtocol Move(int id)
		{
			throw new NotImplementedException();
		}

		public IProtocol Reload(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IProtocol> Send()
		{
			throw new NotImplementedException();
		}
	}
}
