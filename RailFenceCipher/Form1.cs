using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RailFenceCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (tbxPlaint.Text.Length <= 0|| tbxKey.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập chuỗi và khoá");
                return;
            }    
                int key = int.Parse(tbxKey.Text);
            string plainText = tbxPlaint.Text;
            tbxRes.Text = Encrypt(key, plainText);
            riseRail(key, plainText);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (tbxPlaint.Text.Length <= 0 || tbxKey.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập chuỗi và khoá");
                return;
            }
            int key = int.Parse(tbxKey.Text);
            string plainText = tbxPlaint.Text;
            tbxRes.Text = Decrypt(key, plainText);
            riseRail(key, Decrypt(key, plainText));
        }

        public static string Encrypt(int rail, string plainText)
        {
            List<string> railFence = new List<string>();
            for (int i = 0; i < rail; i++)
            {
                railFence.Add("");
            }

            int number = 0;
            int increment = 1;
            foreach (char c in plainText)
            {
                if (number + increment == rail)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFence[number] += c;
                number += increment;
            }

            string buffer = "";
            foreach (string s in railFence)
            {
                buffer += s;
            }
            return buffer;
        }
        ///GIẢI MÃ
        public static string Decrypt(int rail, string cipherText)
        {
            int cipherLength = cipherText.Length;
            List<List<int>> railFence = new List<List<int>>();
            for (int i = 0; i < rail; i++)
            {
                railFence.Add(new List<int>());
            }

            int number = 0;
            int increment = 1;
            for (int i = 0; i < cipherLength; i++)
            {
                if (number + increment == rail)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFence[number].Add(i);
                number += increment;
            }

            int counter = 0;
            char[] buffer = new char[cipherLength];
            for (int i = 0; i < rail; i++)
            {
                for (int j = 0; j < railFence[i].Count; j++)
                {
                    buffer[railFence[i][j]] = cipherText[counter];
                    counter++;
                }
            }
            return new string(buffer);
        }

        public void riseRail(int rail, string cipherText)
        {
            char[,] chr = new char[rail, cipherText.Length];
            for (int j = 0; j < rail; j++)
            {
                for (int k = 0; k < cipherText.Length; k++)
                {
                    chr[j, k] = ' ';
                }               
            }
            int i = 0;
            while (i < cipherText.Length)
            {
                for (int j = 0; j < rail-1; j++)
                {
                    if (i < cipherText.Length)
                    {
                        chr[j, i] = cipherText[i];
                        i++;
                    }
                }
                for (int j = rail - 1; j > 0; j--)
                {
                    if (i < cipherText.Length)
                    {
                        chr[j, i] = cipherText[i];
                        i++;
                    }
                }
            }
            string res = "";
            for (int j = 0; j < rail; j++)
            {
                for (int k = 0; k < cipherText.Length; k++)
                {
                    res += chr[j, k]+" ";
                }
                res += "\n";
            }
            richTextBox1.Text = res;
        }
    }
}
