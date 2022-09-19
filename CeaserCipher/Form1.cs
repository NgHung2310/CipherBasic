﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CeaserCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string cipherText = Encipher(tbxPlaint.Text, int.Parse(tbxKey.Text));
            tbxRes.Text = cipherText;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string cipherText = Decipher(tbxPlaint.Text, int.Parse(tbxKey.Text));
            tbxRes.Text = cipherText;
        }

        public char cipher(char ch, int key)
        {
            string[] lst = new string[26] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };
            if (!char.IsLetter(ch))
            {

                return ch;
            }
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }  

        public string Encipher(string input, int key)
        {
            string output = string.Empty;
            string res = "";
            foreach (char ch in input)
            {
                output += cipher(ch, key);
                res += ch + " -> " + cipher(ch, key) + "\n";
            }
            richTextBox1.Text = res;
            return output;
        }

        public string Decipher(string input, int key)
        {
            char[] chrinput = input.ToCharArray();
            char[] chroutput= Encipher(input, 26 - key).ToCharArray();
            string res = "";
            for(int i=0;i< input.Length;i++)
                res += chrinput[i] + " -> " + chroutput[i] + "\n";
            richTextBox1.Text = res;
            return Encipher(input, 26 - key);
        }


    }
}
