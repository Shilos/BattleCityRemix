using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanki
{
    class GameServer: ListeningClientAbs,  IServer
    {
        private GameServer() { }

        private GameServer(IListener listener)
        {
            ServerListner = listener;
            Rooms = new List<IRoom>();
        }

        public IListener ServerListner { get; private set; }
        public IEnumerable<IRoom> Rooms { get; private set; }

        public override void OnNewConnectionHandler(object Sender, NewConnectionData evntData)
        {
            throw new NotImplementedException();
        }

        public void RUN()
        {
            throw new NotImplementedException();
        }
    }
}
