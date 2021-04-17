using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Satisfactory_map
{
    public partial class Form1 : Form
    {
        public DirectoryInfo dirinfo;
        public Form1()
        {
            InitializeComponent();
            
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Factorygame\\Saved\\SaveGames\\"))
            {
                System.Diagnostics.Process a = new System.Diagnostics.Process();
                a.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Factorygame\\Saved\\SaveGames\\";
                a.Start();
            }
            else
            {
                MessageBox.Show("세이브 파일이 없습니다. \n 실행후 \"새로만들기\" 를 한 후 저장 하여 주세요");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //바로가기는 인식 안됨
            //스팀은 steam://rungameid/526870 으로 실행 함
            //에픽 게임즈는 ... 피드팩이 필요
            MessageBox.Show("잠깐!! 실행시 설치 파일 선택 하세요!");
            
            OpenFileDialog A = new OpenFileDialog();
            DialogResult d = A.ShowDialog();
            if (d == DialogResult.OK)
            {
                string fileName = A.FileName;
                string fileFullName = A.FileName;
                string filePath = fileFullName.Replace(fileName, "");
                Process.Start(fileName,filePath);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("맵 로딩 할때는 \"CLICK/DROP YOURSAVE GAME HERE\" 을 클릭 한후 로딩하세요");
            Process b = new Process();
            b.StartInfo.FileName = "https://satisfactory-calculator.com/ko/interactive-map";
            b.Start();
            b.WaitForExit(100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 m = new Form2();
            m.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/ghrl1121/Satisfactory_Manager");
        }
    }
}
