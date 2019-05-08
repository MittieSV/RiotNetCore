using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RiotNetCore.Helpers
{
    class JsonSerialization
    {
        public static T JsonDeserialize<T>(string json) where T: class
        {
            T result;
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                stream.Position = 0;
                var serializer = new DataContractJsonSerializer(typeof(T));
                result = serializer.ReadObject(stream) as T;
            }
            return result;
        }
    }
}
