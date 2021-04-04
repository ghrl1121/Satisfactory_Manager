using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satisfactory_map
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process a = new Process();
            a.StartInfo.FileName = "https://drive.google.com/drive/my-drive";
            a.Start();
            a.WaitForExit(100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process b = new Process();
            b.StartInfo.FileName = "https://mybox.naver.com/";
            b.Start();
            b.WaitForExit(100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process c = new Process();
            c.StartInfo.FileName = "https://www.dropbox.com/home";
            c.Start();
            c.WaitForExit(100);
        }
    }
}
