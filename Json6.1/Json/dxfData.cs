using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace SYSTEM_DAT
{
    [DataContract(Name = "DxfDat")]              // ← [DataContract(Name="???")]  は、JSONのキー名
    public class CDxfDat
    {
        [DataMember(Name = "Path1")]              // ←[DataMember(Name="???")]   は、JSONのキーに紐づく値
        public string strPathName1 { get; set; }
        [DataMember(Name = "Path2")]
        public string strPathName2 { get; set; }

        [DataMember(Name = "List1")]                // ←　LISTも同じ
        public List<CListDat_var> lstTest { get; set; }       // テスト

        [DataMember(Name = "Dictionary1")]                // ←　Dictionaryも同じ
        public Dictionary<int, CListDat_var> dctTest { get; set; }       // テスト
    }

    [DataContract(Name = "List_var")]                // ←
    public class CListDat_var
    {
        public CListDat_var(string str) { strTest = str; }

        [DataMember(Name = "strTest")]                // ←
        public string strTest { get; set; }
    }
}
