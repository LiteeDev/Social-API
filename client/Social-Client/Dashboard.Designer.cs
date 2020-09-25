namespace Social_Client
{
    partial class Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lastLoginlbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.accountCreatedLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.accountCreatedLbl);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lastLoginlbl);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.emailLbl);
            this.panel1.Controls.Add(this.userLbl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 135);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // userLbl
            // 
            this.userLbl.AutoSize = true;
            this.userLbl.Location = new System.Drawing.Point(115, 8);
            this.userLbl.Name = "userLbl";
            this.userLbl.Size = new System.Drawing.Size(41, 13);
            this.userLbl.TabIndex = 2;
            this.userLbl.Text = "coming";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(115, 31);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(68, 13);
            this.emailLbl.TabIndex = 3;
            this.emailLbl.Text = "email coming";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Login:";
            // 
            // lastLoginlbl
            // 
            this.lastLoginlbl.AutoSize = true;
            this.lastLoginlbl.Location = new System.Drawing.Point(115, 54);
            this.lastLoginlbl.Name = "lastLoginlbl";
            this.lastLoginlbl.Size = new System.Drawing.Size(49, 13);
            this.lastLoginlbl.TabIndex = 5;
            this.lastLoginlbl.Text = "lastLogin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Account Created:";
            // 
            // accountCreatedLbl
            // 
            this.accountCreatedLbl.AutoSize = true;
            this.accountCreatedLbl.Location = new System.Drawing.Point(115, 79);
            this.accountCreatedLbl.Name = "accountCreatedLbl";
            this.accountCreatedLbl.Size = new System.Drawing.Size(83, 13);
            this.accountCreatedLbl.TabIndex = 7;
            this.accountCreatedLbl.Text = "accountCreated";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 159);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lastLoginlbl;
        private System.Windows.Forms.Label accountCreatedLbl;
        private System.Windows.Forms.Label label4;
    }
}