using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKNG_
{
    public partial class CDlgOKNG : Form
    {
        public CDlgOKNG(bool bflg)
        {
            InitializeComponent();

            //(bflg == true) ? pictureBox1.Image = System.Drawing.Image.FromFile("./OK.bmp") : pictureBox1.Image = System.Drawing.Image.FromFile("./NG.bmp");


            if (bflg == true)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile("./OK.bmp");
            }
            else
            {
                pictureBox1.Image = System.Drawing.Image.FromFile("./NG.bmp");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
