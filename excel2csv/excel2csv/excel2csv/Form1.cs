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

namespace excel2csv
{
    public partial class Form1 : Form
    {
        private string strExcelPath = null;
        private string strPyExePath = @"D:\ProgramData\Anaconda3\envs\opencv\python.exe";
        private string strPyCodeExePath = @"D:\se-ji\Desktop\Python\ImagePrc\ImagePrc_seikei.py";


        public Form1()
        {
            this.AllowDrop = true;
            InitializeComponent();

        }

        private void btnExcel2Csv_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 背景色を変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackCkr_Click(object sender, EventArgs e)
        {
            ChangeCellBackColor();
        }

        /// <summary>
        /// ドラッグ & ドロップ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDragDrop_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたファイルの一覧を取得
            string[] sFileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (sFileName.Length <= 0)
            {
                return;
            }

            // ドロップ先がTextBoxであるかチェック
            TextBox TargetTextBox = sender as TextBox;

            if (TargetTextBox == null)
            {
                // TextBox以外のためイベントを何もせずイベントを抜ける。
                return;
            }

            // 現状のTextBox内のデータを削除
            TargetTextBox.Text = "";

            // TextBoxドラックされた文字列を設定
            TargetTextBox.Text = sFileName[0]; // 配列の先頭文字列を設定

            strExcelPath = sFileName[0];        // Excelのパス入力
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            ViewMouseDropAllow_FilePath(e);
        }

        /// <summary>
        /// ドラッグ＆ドロップ　"+"表示処理
        /// </summary>
        /// <param name="e"></param>
        private void ViewMouseDropAllow_FilePath(DragEventArgs e)
        {
            // ドラッグ中のファイルやディレクトリの取得
            string[] sFileName = (string[])e.Data.GetData(DataFormats.FileDrop);

            //ファイルがドラッグされている場合、
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 配列分ループ
                foreach (string sTemp in sFileName)
                {
                    // ファイルパスかチェック
                    if (File.Exists(sTemp) == false)
                    {
                        // ファイルパス以外なので何もしない
                        return;
                    }
                    else
                    {
                        break;
                    }
                }

                // カーソルを[+]へ変更する
                // ここでEffectを変更しないと、以降のイベント（Drop）は発生しない
                e.Effect = DragDropEffects.Copy;
            }
        }


        /// <summary>
        /// セルの背景色を変更する
        /// </summary>
        private void ChangeCellBackColor()
        {
            // Excel操作用オブジェクト
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbooks xlBooks = null;
            Microsoft.Office.Interop.Excel.Workbook xlBook = null;
            Microsoft.Office.Interop.Excel.Sheets xlSheets = null;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = null;

            // Excelアプリケーション生成
            xlApp = new Microsoft.Office.Interop.Excel.Application();

            // 既存のBookを開く
            xlBooks = xlApp.Workbooks;
            xlBook = xlBooks.Open(strExcelPath);

            // xlBook = xlBooks.Open(System.IO.Path.GetFullPath(@"..\work01.xlsx"));

            // シートを選択する
            xlSheets = xlBook.Worksheets;
            // 1シート目を操作対象に設定する
            // ※Worksheets[n]はオブジェクト型を返すため、Worksheet型にキャスト
            xlSheet = xlSheets[1] as Microsoft.Office.Interop.Excel.Worksheet;

            // 表示
            xlApp.Visible = true;

            // セルのオブジェクト
            Microsoft.Office.Interop.Excel.Range xlRange = null;
            Microsoft.Office.Interop.Excel.Range xlCells = null;

            // B3セルを指定
            xlCells = xlSheet.Cells;
            xlRange = xlCells[3, 2] as Microsoft.Office.Interop.Excel.Range;

            // ◆現在の値を表示◆
            MessageBox.Show(xlRange.Value);

            // ◆値を設定◆
            xlRange.Value = "変更後の値";

            // 変更後の値を表示
            MessageBox.Show(xlRange.Value);

            // ■■■以下、COMオブジェクトの解放■■■

            // cell解放
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlCells);

            // Sheet解放
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheets);

            // Book解放
            //xlBook.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks);

            // Excelアプリケーションを解放
            //xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

        }

        private void txtExcelOpen_DragDrop(object sender, DragEventArgs e)
        {
            // ドラッグ中のファイルやディレクトリの取得
            string[] sFileName = (string[])e.Data.GetData(DataFormats.FileDrop);

            ExcelPrc.ReadExcelDat(string.Join("", sFileName));
        }

        /// <summary>
        /// ドラッグ＆ドロップ　マウス表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtExcelOpen_DragEnter(object sender, DragEventArgs e)
        {
            ViewMouseDropAllow_FilePath(e);
        }

        private void btnExePython_Click(object sender, EventArgs e)
        {
            PythonExecutor pe = new PythonExecutor();
            pe.FileName = strPyExePath;
            pe.WorkingDirectory = @"D:\TEMP";
            pe.Arguments = strPyCodeExePath;
            pe.InputString = "1,2,3,4,5,6,7,8,9,10"; //標準入力に与えるデータ
            pe.Execute(); //実行
            Console.WriteLine(pe.StandardOutput); //標準出力の結果を出力
        }
    }
}
