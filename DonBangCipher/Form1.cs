using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DonBangCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string key = tbxKey.Text;
            string plainText = tbxPlaint.Text;
            tbxRes.Text = Encrypt(plainText, key);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string key = tbxKey.Text;
            string plainText = tbxPlaint.Text;
            tbxRes.Text = Decrypt(plainText, key);
        }

        string Encrypt(string plainText, string key)
        {
            try
            {
                string res = "";
                res += "ABCDEFGHIJKLMNOPQRSTUVWXYZ\n";
                res += key+"\n";
                char[] chars = new char[plainText.Length];
                for (int i = 0; i < plainText.Length; i++)
                {
                    if (plainText[i] == ' ')
                    {
                        chars[i] = ' ';
                    }
                    else
                    {
                        int j = plainText[i] - 97;
                        chars[i] = key[j];
                        res += plainText[i] + " -> " + key[j]+"\n";
                    }
                }
                richTextBox1.Text = res;
                return new string(chars);
            }
            catch (Exception e)
            {
                MessageBox.Show("Độ dài khóa phải đủ 26 và đủ từ A-Z !!");
            }
            return "";
        }

        public string reverse(string cipherText)
        {
            char[] charArray = cipherText.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        string Decrypt(string cipherText, string key)
        {
            try
            {
                string res = "";
                res += "ABCDEFGHIJKLMNOPQRSTUVWXYZ\n";
                res += key+"\n";               
                char[] chars = new char[cipherText.Length];
                for (int i = 0; i < cipherText.Length; i++)
                {
                    if (cipherText[i] == ' ')
                    {
                        chars[i] = ' ';
                    }
                    else
                    {
                        int j = key.ToUpper().IndexOf(cipherText[i].ToString().ToUpper()) + 97;
                        chars[i] = (char)j;
                        res += cipherText[i] + " -> " + (char)j + "\n";
                    }
                }
                richTextBox1.Text = res;
                return new string(chars);
            }
            catch (Exception e)
            {
                MessageBox.Show("Độ dài khóa phải đủ 26 và đủ từ A-Z !!");
            }
            return "";
        }
    }
}
