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
            //구글
            Process.Start("https://drive.google.com/drive/my-drive");
            Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //네이버
            Process.Start("https://mybox.naver.com/");
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //드롭박스
            Process.Start("https://www.dropbox.com/home");
            Close();
        }
    }
//공부중
//계획은 시간(분) 단위로 각 빽업을 해주는것을 원했지만...
//역시 간딴한 C# 공부는 없다고 전했다...
}
