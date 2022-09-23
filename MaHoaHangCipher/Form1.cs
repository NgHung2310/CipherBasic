using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaHoaHangCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            int b;
            if(tbxPlaint.Text.Length<=0|| tbxKey.Text.Length<=0 || !int.TryParse(tbxKey.Text,out b))
            {
                MessageBox.Show("Vui long nhap dung thong tin!!");
                return;
            }    
            char[,] tableChar = tableCharEncipher(tbxPlaint.Text, tbxKey.Text);
            string chrres = "";
            for (int i = 0; i < tableChar.GetLength(0); i++)
            {
                for (int j = 0; j < tableChar.GetLength(1); j++)
                    chrres += tableChar[i, j]+"\t";
                chrres += "\n\n";
            }
            //tableCharText(tbxPlaint.Text, tbxKey.Text);
            richTextBox1.Text=chrres;
            tbxRes.Text = Encipher(tbxPlaint.Text, tbxKey.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            int b;
            if (tbxPlaint.Text.Length <= 0 || tbxKey.Text.Length <= 0 || !int.TryParse(tbxKey.Text, out b))
            {
                MessageBox.Show("Vui long nhap dung thong tin!!");
                return;
            }
            char[,] tableChar = tableCharDecipher(tbxPlaint.Text, tbxKey.Text);
            string chrres = "";
            for (int i = 0; i < tableChar.GetLength(0); i++)
            {
                for (int j = 0; j < tableChar.GetLength(1); j++)
                    chrres += tableChar[i, j] + "\t";
                chrres += "\n\n";
            }
            //tableCharText(tbxPlaint.Text, tbxKey.Text);
            richTextBox1.Text = chrres;
            tbxRes.Text = Decipher(tbxPlaint.Text, tbxKey.Text);
        }

        public int[] getKeyIndexs(string key)
        {   
            char[] charKey = key.ToCharArray();
            int[] numKey = new int[charKey.Length];
            for (int i = 0; i < charKey.Length; i++)
                numKey[i] = int.Parse(charKey[i].ToString());
            return numKey;
        }

        public char[,] tableCharEncipher(string plainText,string key) 
        {
            int m = 0;
            int n = 0;
            n = getKeyIndexs(key).Length;
            int[] keyIndexs = getKeyIndexs(key);
            char[] charText= plainText.ToCharArray();
            if(charText.Length % n==0)
                m = charText.Length / n ;
            else
                m = charText.Length / n + 1;
            char[,] tableChar = new char[m, n];
            int k = 0;
            for (int i = 0; i < m; i++)
                for(int j=0;j<n;j++)
                    if (k < charText.Length)
                    {
                        tableChar[i, j] = charText[k];
                        k++;
                    }
                    else
                        tableChar[i, j] = char.Parse(" ");

            char[,] res=new char[m+1,n];
            for (int i = 0; i < n; i++)
                res[0, i] = char.Parse(keyIndexs[i].ToString());
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    res[i + 1, j] = tableChar[i, j];
            return res;
        }

        public string Encipher(string plainText, string key)
        {
            char[,] tableChar = tableCharEncipher(plainText, key);
            int[] keyIndexs = getKeyIndexs(key);
            string res = "";
            for (int j = 0; j < tableChar.GetLength(1); j++)
            {
                for (int i = 1; i < tableChar.GetLength(0); i++)
                {
                    
                    if(tableChar[i, Array.IndexOf(keyIndexs, j + 1)] != char.Parse(" "))
                        res += tableChar[i, Array.IndexOf(keyIndexs, j+1)];
                }    
            } 
            return res;
        }

        public char[,] tableCharDecipher(string plainText, string key)
        {
            int m = 0;
            int n = 0;
            n = getKeyIndexs(key).Length;
            int[] keyIndexs = getKeyIndexs(key);
            char[] charText = plainText.ToCharArray();
            if (charText.Length % n == 0)
                m = charText.Length / n;
            else
                m = charText.Length / n + 1;
            int modnum = charText.Length % n;
            
            int k = 0;
            char[,] res = new char[m + 1, n];
            for (int i = 0; i < n; i++)
                res[0, i] = char.Parse(keyIndexs[i].ToString());
            for (int j = 0; j < n; j++)
                for (int i = 0; i < m; i++)
                {
                    //if (k < charText.Length&&i!=5)
                    if ((i<m-1|| Array.IndexOf(keyIndexs, j + 1) < modnum)&& k < charText.Length)
                    {
                        res[i + 1, Array.IndexOf(keyIndexs, j + 1)] = charText[k];
                        k++;
                    }
                    else
                        res[i + 1, Array.IndexOf(keyIndexs, j + 1)] = char.Parse(" ");
                }
            return res;
        }

        public string Decipher(string plainText, string key)
        {
            char[,] tableChar = tableCharDecipher(plainText, key);
            int[] keyIndexs = getKeyIndexs(key);
            string res = "";
            for (int i = 1; i < tableChar.GetLength(0); i++)
            {
                for (int j = 0; j < tableChar.GetLength(1); j++)
                {
                    if (tableChar[i, j] != char.Parse(" "))
                        res += tableChar[i,j];
                }
            }
            return res;
        }
    }
}
