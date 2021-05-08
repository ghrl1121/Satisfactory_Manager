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
            Process.Start("https://drive.google.com/drive/my-drive");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://mybox.naver.com/");
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.dropbox.com/home");
            Close();
        }
    }
}
