using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using UTILITY;
using SYSTEM_DAT;

namespace ErrMap
{
    public partial class Form1 : Form
    {
        CSettingDat m_setDat;            // セッティングデータ

        readonly Encoding CON_ENCODING = Encoding.UTF8;  // ファイル入出力で適用するEncoding

        public Form1()
        {
            InitializeComponent();

            // JSONデータ LOAD
            m_setDat = new SYSTEM_DAT.CSettingDat();

            // setting.json 読込
            string strReadDat = null;
            if (CUtility.Read_TextFile(("./settingdat.json"), ref strReadDat, CON_ENCODING) == true)
            {
                // ★JSON 読込　
                m_setDat = JSON_UTILS.CJsonUtils.ToObject<SYSTEM_DAT.CSettingDat>(strReadDat, CON_ENCODING);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // JSON 書き込みデータの用意
            m_setDat.strPathName1 = "test1";
            m_setDat.strPathName2 = "Test2";
            m_setDat.strPathName3 = "Test3";

            // 1次元リスト
            m_setDat.lstTest = new List<CListDat_var>();
            m_setDat.lstTest.Add(new CListDat_var("listTest1"));
            m_setDat.lstTest.Add(new CListDat_var("listTest2"));


            // 1次元 Dictionary
            m_setDat.dctTest = new Dictionary<int, CListDat_var>();
            m_setDat.dctTest.Add(1, new CListDat_var("dctTest1"));
            m_setDat.dctTest.Add(2, new CListDat_var("dctTest2"));


            // 2次元　リスト
            m_setDat.lst2Test = new List<C2DemListDat_var>();
     
            CListDat_var m_lstdat_var = new CListDat_var("1223");       // ダミー値

            C2DemListDat_var m_2DEmLstBuf = new C2DemListDat_var();
            m_2DEmLstBuf.C2DemListDat_var_Add(m_lstdat_var);
            m_2DEmLstBuf.C2DemListDat_var_Add(m_lstdat_var);
            m_2DEmLstBuf.C2DemListDat_var_Add(m_lstdat_var);
            m_2DEmLstBuf.C2DemListDat_var_Add(m_lstdat_var);

            m_setDat.lst2Test.Add(m_2DEmLstBuf); // 2次元ListにAdd

       

            // ★JSON 出力
            File.WriteAllText("./settingdat.json", JSON_UTILS.CJsonUtils.ToJson(m_setDat, CON_ENCODING), CON_ENCODING);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
