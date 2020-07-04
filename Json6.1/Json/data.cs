using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace SYSTEM_DAT
{
    [DataContract(Name = "setting")]              // ← [DataContract(Name="???")]  は、JSONのキー名
    public class CSettingDat
    {
        [DataMember(Name = "Path1")]              // ←[DataMember(Name="???")]   は、JSONのキーに紐づく値
        public string strPathName1 { get; set; }
        [DataMember(Name = "Path2")]
        public string strPathName2 { get; set; }
        [DataMember(Name = "Path3")]
        public string strPathName3 { get; set; }


        // 1次元List
        [DataMember(Name = "List1")]                // ←　LISTも同じ
        public List<CListDat_var> lstTest { get; set; }       // テスト

        // 1次元Dictionary
        [DataMember(Name = "Dictionary1")]                // ←　Dictionaryも同じ
        public Dictionary<int, CListDat_var> dctTest { get; set; }       // テスト

        // 2次元List
        [DataMember(Name = "List2")]                // ←　LISTも同じ
        public List<C2DemListDat_var> lst2Test { get; set; }       // テスト
    }

    [DataContract(Name = "List_var")]                // ←
    public class CListDat_var
    {
        public CListDat_var(string str) { strTest = str; }

        [DataMember(Name = "strTest")]                // ←
        public string strTest { get; set; }
    }

    //[DataContract(Name = "List2_var")]                // ←
    public class C2DemListDat_var
    {
    //    [DataMember(Name = "strLst2Test")]                // ←
        public List<CListDat_var> chldLstDatvar { get; set; }       // テスト

        public C2DemListDat_var()
        {
            chldLstDatvar = new List<CListDat_var>();
        }

        public void C2DemListDat_var_Add(CListDat_var buf)
        {
            chldLstDatvar.Add(buf);
        }
    }
}
