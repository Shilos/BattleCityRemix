using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Tanki

{

    /// <summary> Сереализатор. Используется в ISender, IReceiver. </summary>

    public class Serializator : ISerializator

    {

        /// <summary> Де-Сереализатор </summary>

        /// <param name="bytes"> Масив байт требующий Де-Сереализации</param>

        /// <returns> IPackage </returns>

        public IPackage Deserialize(byte[] bytes)

        {

            MemoryStream memStream = new MemoryStream();

            BinaryFormatter binForm = new BinaryFormatter();

            memStream.Write(bytes, 0, bytes.Length);

            memStream.Seek(0, SeekOrigin.Begin);

            Package obj = (Package)binForm.Deserialize(memStream);



            return obj;

        }







        /// <summary> Сереализатор </summary>

        /// <param name="obj"> Объект требующий Сереализации</param>

        /// <returns> Возвращает массив байт </returns>

        public byte[] Serialize(object obj)

        {

            if (obj == null)

                return null;

            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())

            {

                bf.Serialize(ms, obj);

                return ms.ToArray();

            }

        }

    }

}
