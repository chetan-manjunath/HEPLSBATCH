namespace Travel_schedule
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
            this.SuspendLayout();
            // 
            // button1Add
            // 
            this.button1Add.Location = new System.Drawing.Point(323, 104);
            this.button1Add.Name = "button1Add";
            this.button1Add.Size = new System.Drawing.Size(106, 42);
            this.button1Add.TabIndex = 0;
            this.button1Add.Text = "Add";
            this.button1Add.UseVisualStyleBackColor = true;
            // 
            // button2View
            // 
            this.button2View.Location = new System.Drawing.Point(323, 188);
            this.button2View.Name = "button2View";
            this.button2View.Size = new System.Drawing.Size(106, 41);
            this.button2View.TabIndex = 1;
            this.button2View.Text = "View";
            this.button2View.UseVisualStyleBackColor = true;
            // 
            // button3Edit
            // 
            this.button3Edit.Location = new System.Drawing.Point(323, 270);
            this.button3Edit.Name = "button3Edit";
            this.button3Edit.Size = new System.Drawing.Size(106, 44);
            this.button3Edit.TabIndex = 2;
            this.button3Edit.Text = "Edit";
            this.button3Edit.UseVisualStyleBackColor = true;
            // 
            // button4SignOut
            // 
            this.button4SignOut.Location = new System.Drawing.Point(673, 27);
            this.button4SignOut.Name = "button4SignOut";
            this.button4SignOut.Size = new System.Drawing.Size(90, 45);
            this.button4SignOut.TabIndex = 3;
            this.button4SignOut.Text = "Sign Out";
            this.button4SignOut.UseVisualStyleBackColor = true;
            // 
            // menuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1Add);
            this.Controls.Add(this.button4SignOut);
            this.Controls.Add(this.button3Edit);
            this.Controls.Add(this.button2View);
            this.Name = "menuForm";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1Add;
        private System.Windows.Forms.Button button2View;
        private System.Windows.Forms.Button button3Edit;
        private System.Windows.Forms.Button button4SignOut;
    }
}