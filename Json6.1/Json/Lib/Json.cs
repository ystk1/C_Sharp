using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JSON_UTILS
{
    public static class CJsonUtils
    {
        /// <summary>
        /// オブジェクトからJSONへ変換します
        /// </summary>
        /// <param name="obj">JSONへ変換するオブジェクト</param>
        /// <returns>JSON</returns>
        public static string ToJson(object obj, Encoding enEnCodeCur)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(ms, obj);
                return enEnCodeCur.GetString(ms.ToArray());
                //               return Encoding.UTF8.GetString(ms.ToArray());
            }
        }


        /// <summary>
        /// JSONからオブジェクトへ変換します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">オブジェクトへ変換するJSON</param>
        /// <returns>オブジェクト</returns>
        public static T ToObject<T>(string json, Encoding enEnCodeCur)
        {
            using (MemoryStream ms = new MemoryStream(enEnCodeCur.GetBytes(json)))
            //     using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }
    }
}
