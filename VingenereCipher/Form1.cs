using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VingenereCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            //try
            //{
                string key = tbxKey.Text;
                string plainText = tbxPlaint.Text;
                tbxRes.Text = Encipher(plainText, key);
            //}
            //catch
            //{
            //    MessageBox.Show("Vui lòng nhập chuỗi và khoá là chữ");
            //}
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            //try
            //{
                string key = tbxKey.Text;
                string plainText = tbxPlaint.Text;
                tbxRes.Text = Decipher(plainText, key);
            //}
            //catch 
            //{
            //    MessageBox.Show("Vui lòng nhập chuỗi và khoá là chữ");
            //}
        }

        private int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private string Cipher(string input, string key, bool encipher)
        {
            for (int i = 0; i < key.Length; ++i)
                if (!char.IsLetter(key[i]))
                    return null; // Error

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }

        public string Encipher(string input, string key)
        {
            foreach (char c in key)
            {
                if (!Char.IsLetter(c))
                {
                    MessageBox.Show("Key chỉ được nhập chữ cái");
                    return "";
                }
            }
            char[] chrinput = input.ToCharArray();
            char[] chroutput = Cipher(input, key, true).ToCharArray();
            string res = "";
            for (int i = 0; i < chrinput.Length; i++)
                res += chrinput[i] + " -> " + chroutput[i] + "\n";
            richTextBox1.Text=res;
            return Cipher(input, key, true);
        }

        public string Decipher(string input, string key)
        {
            foreach (char c in key)
            {
                if (!Char.IsLetter(c))
                {
                    MessageBox.Show("Key chỉ được nhập chữ cái");
                    return "";
                }
            }
            char[] chrinput = input.ToCharArray();
            char[] chroutput = Cipher(input, key, false).ToCharArray();
            string res = "";
            for (int i = 0; i < chrinput.Length; i++)
                res += chrinput[i] + " -> " + chroutput[i] + "\n";
            richTextBox1.Text = res;
            return Cipher(input, key, false);
        }

    }
}
