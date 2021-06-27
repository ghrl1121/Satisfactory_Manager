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
using System.Net;
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Dropbox.Api;
using Dropbox.Api.Common;
using Dropbox.Api.Files;
using Dropbox.Api.Team;

namespace Satisfactory_map
{
    public partial class Form2 : Form
    {
        private DriveService service;
        private Button unps;

        public Form2()

        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                //구글
                //구글 API필요
                //참조는 Class1.cs
                MessageBox.Show("공부중입니다. 구글드라이버로 이동합니다.");
                Process.Start("https://drive.google.com/");
               
            }
            else if(radioButton2.Checked == true)
            {
                //네이버
                MessageBox.Show("공부중입니다. 네이버 클라우드에 이동합니다.");
                Process.Start("https://mybox.naver.com/");
            }
            else if(radioButton3.Checked == true)
            {
                //드롭박스
                //드롭박스 API 필요
                //https://github.com/dropbox/dropbox-sdk-dotnet/blob/master/dropbox-sdk-dotnet/Examples/SimpleTest/Program.cs
                MessageBox.Show("공부중입니다. 드롭박스로 이동합니다.");
                Process.Start("https://www.dropbox.com/");
            }
            else
            {
                MessageBox.Show("선택하세요!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog A = new OpenFileDialog();
            A.Multiselect = true;
            DialogResult d = A.ShowDialog();
            if (d == DialogResult.OK)
            {
                string fileName = A.SafeFileName;
                string fileFullName = A.FileName;
                string filePath = fileFullName.Replace(fileName, "");
                textBox1.Text = fileName;
                textBox3.Text = fileFullName;

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

