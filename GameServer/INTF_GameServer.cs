using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net.Sockets;
using System.Threading;

namespace Tanki
{
    //заглушки
    public interface IProtoclol
    {

    }

    public interface ISender
    {

    }

    public interface IGamer
    {
        String id { get; set; }
        Socket Socket { get; set; }
    }

    public interface IGameRoom
    {
        String RoomId { get; set; }
        Socket RoomListner { get; }
        IEnumerable<IGamer> Gamers { get; }
        void AddGamer(IGamer newGamer);

        IMessageQueue MessageQueue { get; }
        ISender Sender { get; }
        void RUN();

    }


    public interface IMessageQueue
    {
        IEnumerable<IProtoclol> Queue {get;}
        Timer Timer { get; }
        void Enque(IProtoclol msg);
        void RUN();

    }

    public interface IServer
    {
        Socket ServerListner { get; }
        IEnumerable<IGameRoom> Rooms { get; }


    }
}
