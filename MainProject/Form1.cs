using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CeaserCipher.Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DonBangCipher.Form1().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MaHoaHangCipher.Form1().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new RailFenceCipher.Form1().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new PlayFairCipher.Form1().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new VingenereCipher.Form1().Show();
        }
    }
}
