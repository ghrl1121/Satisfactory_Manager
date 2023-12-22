using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Satisfactory_map
{
    public partial class Form2 : Form
    {



        public Form2()

        {
            InitializeComponent();
            MessageBox.Show("API공부하다 포기했습니다\r\n그냥 링크로 연결됩니다.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //구글
            Process.Start("https://drive.google.com/drive");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //네이버
            Process.Start("https://mybox.naver.com/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //드롭박스
            Process.Start("https://www.dropbox.com/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MEGA
            Process.Start("https://mega.io/");
        }
    }
}

