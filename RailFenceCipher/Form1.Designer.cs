﻿namespace RailFenceCipher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxRes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPlaint = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(561, 215);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(107, 34);
            this.btnDecrypt.TabIndex = 30;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 270);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 29);
            this.label3.TabIndex = 29;
            this.label3.Text = "Cipher text";
            // 
            // tbxRes
            // 
            this.tbxRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRes.Location = new System.Drawing.Point(285, 276);
            this.tbxRes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxRes.Name = "tbxRes";
            this.tbxRes.Size = new System.Drawing.Size(381, 30);
            this.tbxRes.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 29);
            this.label2.TabIndex = 27;
            this.label2.Text = "Key";
            // 
            // tbxKey
            // 
            this.tbxKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxKey.Location = new System.Drawing.Point(285, 155);
            this.tbxKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxKey.Name = "tbxKey";
            this.tbxKey.Size = new System.Drawing.Size(381, 30);
            this.tbxKey.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "Plain text";
            // 
            // tbxPlaint
            // 
            this.tbxPlaint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPlaint.Location = new System.Drawing.Point(285, 76);
            this.tbxPlaint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPlaint.Name = "tbxPlaint";
            this.tbxPlaint.Size = new System.Drawing.Size(381, 30);
            this.tbxPlaint.TabIndex = 24;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(285, 215);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(107, 34);
            this.btnEncrypt.TabIndex = 23;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(712, 76);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(777, 243);
            this.richTextBox1.TabIndex = 31;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 370);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxRes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPlaint);
            this.Controls.Add(this.btnEncrypt);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "RailFenceCipher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxRes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPlaint;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

