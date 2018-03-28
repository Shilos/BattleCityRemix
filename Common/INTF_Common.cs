using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanki

{

    /// <summary>

    /// Интерфейс описующий информацию об игре (IGameRoom).

    /// Является частью интерфейса IGameRoom.

    /// Предназначен для обмена между клиентом/серверером

    /// Реализующий клас обязан иметь атрибут [Serializable]

    /// </summary>

    public interface IRoomStat

    {

        string Id { get; set; }

        int Players_count { get; set; }

        string Creator_Id { get; set; }

    }







    /// <summary>

    /// Интерфейс описующий информацию об объекте.

    /// Является родителем для ITank, IBullet, IBlock.

    /// Предназначен для обмена между клиентом/серверером

    /// Реализующий клас обязан иметь атрибут [Serializable]

    /// </summary>

    public interface IEntity

    {

        Adds_Common.Position Position { get; set; }

        Adds_Common.Direction Direction { get; set; }

        bool Can_Shoot { get; set; }

        bool Is_Alive { get; set; }

        bool Can_Be_Destroyed { get; set; }

    }







    /// <summary>

    /// Интерфейс описующий информацию о Танке(Игроке).

    /// Является наследником IEntity.

    /// Является частью IPlayer(подругому IGamer).

    /// Используется в интерфейсах IServerEngine и IClientEngine.

    /// Реализующий клас обязан иметь атрибут [Serializable]

    /// </summary>

    public interface ITank : IEntity

    {

        bool Can_Shot { get; set; }

        int Lives { get; set; }

        Adds_Common.Teem Teem { get; set; }

    }







    /// <summary>

    /// Интерфейс описующий информацию о Пуле.

    /// Является наследником IEntity.

    /// Используется в интерфейсах IServerEngine и IClientEngine.

    /// Реализующий клас обязан иметь атрибут [Serializable]

    /// </summary>

    public interface IBullet : IEntity

    {

        string Parent_Id { get; set; }

    }







    /// <summary>

    /// Интерфейс описующий информацию о Преградах (Пеньках).

    /// Является наследником IEntity.

    /// Используется в интерфейсах IServerEngine и IClientEngine.

    /// Реализующий клас обязан иметь атрибут [Serializable]

    /// </summary>

    public interface IBlock : IEntity { }







    /// <summary> Интерфейс описывает сущность Отправляющюю сообщения клиенту/серверу</summary>

    public interface ISender { }









    /// <summary> Интерфейс описывает сущность Принимающюю сообщения от клиента/сервера </summary>

    public interface IReceiver { }







    /// <summary> Интерфейс описывает очередь сообщений клиента/сервера </summary>

    public interface IMesegeQueue { }







    /// <summary> Пакет данных - играет роль сообщения между клинтом/сервером.

    /// Используется в IMesegeQueue, ISender, IReceiver</summary>

    /// Реализующий клас обязан иметь атрибут [Serializable]

    public interface IPackage

    {

        string Sender_id { get; set; }

        object Data { get; set; }

    }





    /// <summary> Сереализатор. Используется в ISender, IReceiver. </summary>

    public interface ISerializator

    {

        byte[] Serialize(object obj);

        IPackage Deserialize(byte[] bytes);

    }

}
