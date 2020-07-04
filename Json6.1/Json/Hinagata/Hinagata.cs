using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ErrMap
{
    // ↓↓ 定型分 (共通部分)↓↓
    // ENUM 型Table生成
    enum EN_MUSASHI_EXCEPT
   // { }

    /// <summary>
    /// ジェネレータ用　変数
    /// </summary>
    [Serializable]          // シリアライズ化して取り扱う
    class CGenerator_var
    {
        public EN_MUSASHI_EXCEPT enErrCode_Key;        // Error code
        public string strVarName;    // VarName
        public string strComment;      // Comment

        public CGenerator_var(EN_MUSASHI_EXCEPT en, string str1, string str2)
        {
            enErrCode_Key =en;
            strVarName = str1;
            strComment = str2;
        }

        public CGenerator_var() { }
    }
    // ↑↑

    // /// <summary>
    // /// ジェネレータ用　変数
    // /// </summary>
    // [Serializable]          // シリアライズ化して取り扱う
    //  class CGenerator_var
    // {
    //     public EN_MUSASHI_EXCEPT enErrCode_Key;        // Error code
    //     public string strVarName;    // VarName
    //     public string strComment;      // Comment

    //     public CGenerator_var(EN_MUSASHI_EXCEPT en, string str1, string str2)
    //     {
    //         enErrCode_Key = en;
    //         strVarName = str1;
    //         strComment = str2;
    //     }
    // }
    // // ↑↑

class CMusashiExcept
{
	
           // シングルトン
        private static CMusashiExcept _singleInstance = new CMusashiExcept();

        public static CMusashiExcept GetInstance()
        {
            return _singleInstance;
        }

        private CMusashiExcept()
        {
            //TODO: initialization
            CreateDictErrDat(clsGenArray);
        }

// Error Code 実体
private Dictionary<EN_MUSASHI_EXCEPT, CGenerator_var> DictErrDat = new Dictionary<EN_MUSASHI_EXCEPT, CGenerator_var>();

// 例外 throw
   public  string Throw_Musashi_Except(EN_MUSASHI_EXCEPT endat){
     throw new Exception(string.Format(DictErrDat[endat].strComment));
    } 

// Set Error Code Dat
private void CreateDictErrDat(CGenerator_var[] lstldat)
{
    for(int i=0; i <lstldat.Count(); i++){
    CGenerator_var m_var = new CGenerator_var();

    // 値セット
    m_var = lstldat[i];

    DictErrDat.Add( m_var.enErrCode_Key,m_var);
    } 
}

// Table生成
CGenerator_var[] clsGenArray
//// $Except code instance////
}
}
