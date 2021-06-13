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
            OpenFileDialog A = new OpenFileDialog();
            DialogResult d = A.ShowDialog();
            if (d == DialogResult.OK)
            {
                string fileName = A.FileName;
                string fileFullName = A.FileName;
                string filePath = fileFullName.Replace(fileName , "");
                textBox1.Text = fileName;

            }
          else
            {
                textBox1.Text = "파일을 선택하세요";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //구글
                Process.Start("https://drive.google.com/");
            }
            else if (radioButton2.Checked == true)
            {
                //네이버
                Process.Start("https://mybox.naver.com/");
            }
            else if (radioButton3.Checked == true)
            {
                //드롭박스
                Process.Start("https://www.dropbox.com/home");
            }
            else
            {
                MessageBox.Show("선택하세요!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog A = new OpenFileDialog();
            DialogResult d = A.ShowDialog();
            if (d == DialogResult.OK)
            {
                string fileName = A.FileName;
                string fileFullName = A.FileName;
                string filePath = fileFullName.Replace(fileName, "");
                textBox1.Text = fileName;

            }
            else
            {
                textBox1.Text = "파일을 선택하세요";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                timer1.Start();
                //for(int i ; i < 100 ;i++)
                //{
                //    textBox2.Text += 
                //}
            }
        }
    }

//공부중
//계획은 시간(분) 단위로 각 빽업을 해주는것을 원했지만...
//역시 간딴한 C# 공부는 없다고 전했다...
//빽업하기도....;;
}

