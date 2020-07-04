using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;



namespace excel2csv
{

    public class PythonExecutor
    {
        public String FileName { get; set; }
        public String WorkingDirectory { get; set; }
        public String Arguments { get; set; }
        public String InputString { get; set; }
        public String StandardOutput { get; set; }
        public int ExitCode { get; set; }

        private StringBuilder standardOutputStringBuilder = new StringBuilder();

        public PythonExecutor()
        {

        }

        /// 実行ボタンクリック時の動作
        public void Execute()
        {

            ProcessStartInfo psInfo = new ProcessStartInfo();
            psInfo.FileName = this.FileName;
            psInfo.WorkingDirectory = this.WorkingDirectory;
            psInfo.Arguments = this.Arguments;

            psInfo.CreateNoWindow = false;  //コンソールウィンドウ　開く(false)
            psInfo.UseShellExecute = false;
            psInfo.RedirectStandardInput = true;
            psInfo.RedirectStandardOutput = true;
            psInfo.RedirectStandardError = true;

            // Process p = Process.Start(psInfo);
            Process p = new System.Diagnostics.Process();
            p.StartInfo = psInfo;
            p.OutputDataReceived += p_OutputDataReceived;
            p.ErrorDataReceived += p_ErrorDataReceived;

            // プロセスの実行
            p.Start();

            // 標準入力への書き込み
            using (StreamWriter sw = p.StandardInput)
            {
                sw.Write(InputString);
            }

            //非同期で出力とエラーの読み取りを開始
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            // 終わるまでまつ
            p.WaitForExit();
            this.ExitCode = p.ExitCode;
            this.StandardOutput = standardOutputStringBuilder.ToString();
        }

        /// <summary>
        /// 標準出力データを受け取った時の処理
        /// </summary>
        void p_OutputDataReceived(object sender,
            System.Diagnostics.DataReceivedEventArgs e)
        {
            //processMessage(sender, e);
            if (e != null && e.Data != null && e.Data.Length > 0)
            {
                standardOutputStringBuilder.Append(e.Data + "\n");
            }
        }

        /// <summary>
        /// 標準エラーを受け取った時の処理
        /// </summary>
        void p_ErrorDataReceived(object sender,
            System.Diagnostics.DataReceivedEventArgs e)
        {
            //必要な処理を書く
        }
    }
}
