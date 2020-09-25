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
            this.copyUserIdBtn = new System.Windows.Forms.Button();
            this.encodedLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.accountCreatedLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lastLoginlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.userLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginHistoryBox = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginHistoryBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.copyUserIdBtn);
            this.panel1.Controls.Add(this.encodedLbl);
            this.panel1.Controls.Add(this.label5);
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
            this.panel1.Size = new System.Drawing.Size(329, 259);
            this.panel1.TabIndex = 0;
            // 
            // copyUserIdBtn
            // 
            this.copyUserIdBtn.Location = new System.Drawing.Point(6, 224);
            this.copyUserIdBtn.Name = "copyUserIdBtn";
            this.copyUserIdBtn.Size = new System.Drawing.Size(98, 23);
            this.copyUserIdBtn.TabIndex = 10;
            this.copyUserIdBtn.Text = "Copy User ID";
            this.copyUserIdBtn.UseVisualStyleBackColor = true;
            this.copyUserIdBtn.Click += new System.EventHandler(this.copyIdbtn);
            // 
            // encodedLbl
            // 
            this.encodedLbl.AutoSize = true;
            this.encodedLbl.Location = new System.Drawing.Point(115, 104);
            this.encodedLbl.Name = "encodedLbl";
            this.encodedLbl.Size = new System.Drawing.Size(58, 13);
            this.encodedLbl.TabIndex = 9;
            this.encodedLbl.Text = "encodedId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Encoded UserId:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Account Created:";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Login:";
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
            // userLbl
            // 
            this.userLbl.AutoSize = true;
            this.userLbl.Location = new System.Drawing.Point(115, 8);
            this.userLbl.Name = "userLbl";
            this.userLbl.Size = new System.Drawing.Size(41, 13);
            this.userLbl.TabIndex = 2;
            this.userLbl.Text = "coming";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // loginHistoryBox
            // 
            this.loginHistoryBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loginHistoryBox.Location = new System.Drawing.Point(347, 40);
            this.loginHistoryBox.Name = "loginHistoryBox";
            this.loginHistoryBox.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.loginHistoryBox.Size = new System.Drawing.Size(776, 231);
            this.loginHistoryBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(347, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Login History (Example)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Friends";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 283);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loginHistoryBox);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginHistoryBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label encodedLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button copyUserIdBtn;
        public System.Windows.Forms.DataGridView loginHistoryBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}