using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JSON_UTILS
{
    public static class CJsonUtils
    {
        /// <summary>
        /// �I�u�W�F�N�g����JSON�֕ϊ����܂�
        /// </summary>
        /// <param name="obj">JSON�֕ϊ�����I�u�W�F�N�g</param>
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
        /// JSON����I�u�W�F�N�g�֕ϊ����܂�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">�I�u�W�F�N�g�֕ϊ�����JSON</param>
        /// <returns>�I�u�W�F�N�g</returns>
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
