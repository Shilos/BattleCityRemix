using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net.Sockets;
using System.Threading;

namespace Tanki
{
 

    //public interface IGamer
    //{
    //    String id { get; set; }
    //    Socket Socket { get; set; }
    //}

    //public interface IGameRoom
    //{
    //    String RoomId { get; set; }
    //    Socket RoomListner { get; }
    //    IEnumerable<IGamer> Gamers { get; }
    //    void AddGamer(IGamer newGamer);

    //    IMessageQueue MessageQueue { get; }
    //    ISender Sender { get; }
    //    void RUN();

    //}


    //public interface IMessageQueue : IDisposable
    //{
    //    //IEnumerable<IProtoclol> Queue {get;}
    //    //Timer Timer { get; }
    //    void Enqueue(IProtocol msg);
    //    void RUN();

    //}

    //public enum MsgQueueType
    //{
    //    mqOneByOneProcc,
    //    mqByTimerProcc
    //}

    //public interface IMessageQueueFabric
    //{
    //    IMessageQueue CreateMessageQueue(MsgQueueType queueType, IServerEngine withEngine);
    //}


    public interface IServer
    {
        Socket ServerListner { get; }
        IEnumerable<IRoom> Rooms { get; }


    }
}
