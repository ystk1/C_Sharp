namespace excel2csv
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExcel2Csv = new System.Windows.Forms.Button();
            this.btnBackCkr = new System.Windows.Forms.Button();
            this.txtDragDrop = new System.Windows.Forms.TextBox();
            this.txtExcelOpen = new System.Windows.Forms.TextBox();
            this.btnExePython = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExcel2Csv
            // 
            this.btnExcel2Csv.Location = new System.Drawing.Point(12, 89);
            this.btnExcel2Csv.Name = "btnExcel2Csv";
            this.btnExcel2Csv.Size = new System.Drawing.Size(75, 23);
            this.btnExcel2Csv.TabIndex = 0;
            this.btnExcel2Csv.Text = "csv変換";
            this.btnExcel2Csv.UseVisualStyleBackColor = true;
            this.btnExcel2Csv.Click += new System.EventHandler(this.btnExcel2Csv_Click);
            // 
            // btnBackCkr
            // 
            this.btnBackCkr.Location = new System.Drawing.Point(12, 128);
            this.btnBackCkr.Name = "btnBackCkr";
            this.btnBackCkr.Size = new System.Drawing.Size(75, 23);
            this.btnBackCkr.TabIndex = 1;
            this.btnBackCkr.Text = "背景色変更";
            this.btnBackCkr.UseVisualStyleBackColor = true;
            this.btnBackCkr.Click += new System.EventHandler(this.btnBackCkr_Click);
            // 
            // txtDragDrop
            // 
            this.txtDragDrop.AllowDrop = true;
            this.txtDragDrop.Location = new System.Drawing.Point(12, 12);
            this.txtDragDrop.Multiline = true;
            this.txtDragDrop.Name = "txtDragDrop";
            this.txtDragDrop.ReadOnly = true;
            this.txtDragDrop.Size = new System.Drawing.Size(90, 54);
            this.txtDragDrop.TabIndex = 2;
            this.txtDragDrop.Text = "ここにExcelファイルをドラッグ＆ドロップ";
            this.txtDragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtDragDrop_DragDrop);
            this.txtDragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtDragDrop_DragEnter);
            // 
            // txtExcelOpen
            // 
            this.txtExcelOpen.AllowDrop = true;
            this.txtExcelOpen.Location = new System.Drawing.Point(135, 13);
            this.txtExcelOpen.Multiline = true;
            this.txtExcelOpen.Name = "txtExcelOpen";
            this.txtExcelOpen.ReadOnly = true;
            this.txtExcelOpen.Size = new System.Drawing.Size(100, 53);
            this.txtExcelOpen.TabIndex = 3;
            this.txtExcelOpen.Text = "ExcelOpen\\nここにExcelファイルをドラッグ＆ドロップしてください。";
            this.txtExcelOpen.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtExcelOpen_DragDrop);
            this.txtExcelOpen.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtExcelOpen_DragEnter);
            // 
            // btnExePython
            // 
            this.btnExePython.Location = new System.Drawing.Point(13, 181);
            this.btnExePython.Name = "btnExePython";
            this.btnExePython.Size = new System.Drawing.Size(75, 23);
            this.btnExePython.TabIndex = 4;
            this.btnExePython.Text = "Python実行";
            this.btnExePython.UseVisualStyleBackColor = true;
            this.btnExePython.Click += new System.EventHandler(this.btnExePython_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExePython);
            this.Controls.Add(this.txtExcelOpen);
            this.Controls.Add(this.txtDragDrop);
            this.Controls.Add(this.btnBackCkr);
            this.Controls.Add(this.btnExcel2Csv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcel2Csv;
        private System.Windows.Forms.Button btnBackCkr;
        private System.Windows.Forms.TextBox txtDragDrop;
        private System.Windows.Forms.TextBox txtExcelOpen;
        private System.Windows.Forms.Button btnExePython;
    }
}

