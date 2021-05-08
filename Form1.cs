﻿using System;
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

            Form3 p = new Form3();
            p.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("맵 로딩 할때는 \"CLICK/DROP YOURSAVE GAME HERE\" 을 클릭 한후 로딩하세요");
            Process.Start("https://satisfactory-calculator.com/ko/interactive-map");
            
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
