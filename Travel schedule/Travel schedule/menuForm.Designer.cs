﻿namespace Travel_schedule
{
    partial class menuForm
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
            this.button1Add = new System.Windows.Forms.Button();
            this.button2View = new System.Windows.Forms.Button();
            this.button3Edit = new System.Windows.Forms.Button();
            this.button4SignOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1Add
            // 
            this.button1Add.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1Add.Location = new System.Drawing.Point(86, 169);
            this.button1Add.Name = "button1Add";
            this.button1Add.Size = new System.Drawing.Size(114, 40);
            this.button1Add.TabIndex = 0;
            this.button1Add.Text = "Add";
            this.button1Add.UseVisualStyleBackColor = false;
            this.button1Add.Click += new System.EventHandler(this.Button1Add_Click);
            // 
            // button2View
            // 
            this.button2View.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2View.Location = new System.Drawing.Point(86, 246);
            this.button2View.Name = "button2View";
            this.button2View.Size = new System.Drawing.Size(114, 36);
            this.button2View.TabIndex = 1;
            this.button2View.Text = "View";
            this.button2View.UseVisualStyleBackColor = false;
            this.button2View.Click += new System.EventHandler(this.Button2View_Click);
            // 
            // button3Edit
            // 
            this.button3Edit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3Edit.Location = new System.Drawing.Point(86, 318);
            this.button3Edit.Name = "button3Edit";
            this.button3Edit.Size = new System.Drawing.Size(114, 38);
            this.button3Edit.TabIndex = 2;
            this.button3Edit.Text = "Edit";
            this.button3Edit.UseVisualStyleBackColor = false;
            this.button3Edit.Click += new System.EventHandler(this.Button3Edit_Click);
            // 
            // button4SignOut
            // 
            this.button4SignOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4SignOut.ForeColor = System.Drawing.Color.Black;
            this.button4SignOut.Location = new System.Drawing.Point(650, 52);
            this.button4SignOut.Name = "button4SignOut";
            this.button4SignOut.Size = new System.Drawing.Size(79, 29);
            this.button4SignOut.TabIndex = 3;
            this.button4SignOut.Text = "Sign Out";
            this.button4SignOut.UseVisualStyleBackColor = false;
            this.button4SignOut.Click += new System.EventHandler(this.Button4SignOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 42);
            this.label1.TabIndex = 4;
            this.label1.Text = "Advanced Travel Portal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Welcome...";
            //this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(259, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(387, 96);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hai...\r\nWelcome to the  Advanced Travel portal\r\nand now you are free to completel" +
    "y utilize the\r\nTravel Service from Advanced.\r\n";
            // 
            // menuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1Add);
            this.Controls.Add(this.button4SignOut);
            this.Controls.Add(this.button3Edit);
            this.Controls.Add(this.button2View);
            this.Name = "menuForm";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1Add;
        private System.Windows.Forms.Button button2View;
        private System.Windows.Forms.Button button3Edit;
        private System.Windows.Forms.Button button4SignOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}