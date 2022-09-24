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
            char[,] tableChar = tableCharEncipher(tbxPlaint.Text.Replace(" ", ""), fixKey(tbxKey.Text.Replace(" ", "")));
            string chrres = "";
            for (int i = 0; i < tableChar.GetLength(0); i++)
            {
                for (int j = 0; j < tableChar.GetLength(1); j++)
                    chrres += tableChar[i, j]+"\t";
                chrres += "\n\n";
            }
            richTextBox1.Text=chrres;
            tbxRes.Text = Encipher(tbxPlaint.Text.Replace(" ",""), fixKey(tbxKey.Text.Replace(" ", "")));
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            int b;
            if (tbxPlaint.Text.Length <= 0 || tbxKey.Text.Length <= 0 || !int.TryParse(tbxKey.Text, out b))
            {
                MessageBox.Show("Vui long nhap dung thong tin!!");
                return;
            }
            char[,] tableChar = tableCharDecipher(tbxPlaint.Text.Replace(" ", ""), fixKey(tbxKey.Text.Replace(" ", "")));
            string chrres = "";
            for (int i = 0; i < tableChar.GetLength(0); i++)
            {
                for (int j = 0; j < tableChar.GetLength(1); j++)
                    chrres += tableChar[i, j] + "\t";
                chrres += "\n\n";
            }
            richTextBox1.Text = chrres;
            tbxRes.Text = Decipher(tbxPlaint.Text.Replace(" ", ""), fixKey(tbxKey.Text.Replace(" ", "")));
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
                res[0, i] = tbxKey.Text[i];
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

                    if (tableChar[i, Array.IndexOf(keyIndexs, j + 1)] != char.Parse(" "))
                        res += tableChar[i, Array.IndexOf(keyIndexs, j + 1)];
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
                res[0, i] = tbxKey.Text[i];
            for (int j = 0; j < n; j++)
                for (int i = 0; i < m; i++)
                {
                    if ((i < m - 1 || Array.IndexOf(keyIndexs, j + 1) < modnum) && k < charText.Length)
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
                        res += tableChar[i, j];
                }
            }
            return res;
        }

        private int[] GetShiftIndexes(string key)
        {
            int keyLength = key.Length;
            int[] indexes = new int[keyLength];
            List<KeyValuePair<int, char>> sortedKey = new List<KeyValuePair<int, char>>();
            int i;

            for (i = 0; i < keyLength; ++i)
                sortedKey.Add(new KeyValuePair<int, char>(i, key[i]));

            sortedKey.Sort(
                delegate (KeyValuePair<int, char> pair1, KeyValuePair<int, char> pair2) {
                    return pair1.Value.CompareTo(pair2.Value);
                }
            );

            for (i = 0; i < keyLength; ++i)
                indexes[sortedKey[i].Key] = i;

            return indexes;
        }

        public string fixKey(string key)
        {
            int[] array = getKeyIndexs(key);
            List<int> lst = new List<int>();
            foreach (int item in array)
            {
                if (lst.IndexOf(item) < 0)
                    lst.Add(item);
            }
            lst.Sort();
            int[] subArray = new int[array.Length];
            int k = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == lst[i])
                    {
                        subArray[j] = ++k;
                    }
                }
            } 
            char[] chr = new char[subArray.Length];
            for (int i = 0; i < subArray.Length; i++)
            {
                chr[i] = Char.Parse(subArray[i].ToString());
            }
            return new String(chr); 
        }

    }
}
