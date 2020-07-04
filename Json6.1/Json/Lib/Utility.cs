using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.TEST;
using System.ComponentModel;
using System.IO;

namespace UTILITY
{
    class CUtility
    {

        /// <summary>
        /// 文字列⇒任意数値変換
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse<T>(string input, ref T result)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    //ConvertFromString(string text)の戻りは object なので T型でキャストする
                    result = (T)converter.ConvertFromString(input);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        

        /// <summary>
        /// テキストファイルを読込(　string型 )
        /// </summary>
        /// <param name="strPash"></param>
        /// <param name="strReadDat"></param>
        /// <returns></returns>
        public static bool Read_TextFile(string strPash, ref string strReadDat, Encoding enCode)
        {
            bool bret = false;
            if (System.IO.File.Exists(strPash))
            {
                StreamReader sr = new StreamReader(strPash, enCode);
                strReadDat = sr.ReadToEnd();
                sr.Close();

                bret = true;
            }
            else
            {
                strReadDat = null;
                bret = false;
            }
            return bret;
        }
    }
}
