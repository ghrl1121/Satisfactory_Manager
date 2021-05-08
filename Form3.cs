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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("steam://rungameid/526870");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //모름
            MessageBox.Show("죄송합니다. \n스팀 유저라 피드팩이 필요 합니다.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("잠깐!! 바로가기는 인식이 안됩니다.");
            OpenFileDialog A = new OpenFileDialog();
            DialogResult d = A.ShowDialog();
            if (d == DialogResult.OK)
            {
                string fileName = A.FileName;
                string fileFullName = A.FileName;
                string filePath = fileFullName.Replace(fileName, "");
                Process.Start(fileName, filePath);
            }
            Close();
        }
    }
}
