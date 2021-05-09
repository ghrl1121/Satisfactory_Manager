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
            //스팀
            Process.Start("steam://rungameid/526870");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //에픽게임즈
            //모름 ... 도와주세요!
            //일딴 밑에 에픽게임즈의 링크인데... 달라...!
            //com.epicgames.launcher://apps/[...] <알게 된 이유는 다른게임때문에 알게 된 사연
            MessageBox.Show("죄송합니다. \n스팀 유저라 피드팩이 필요 합니다.");
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            //찾아보기
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
