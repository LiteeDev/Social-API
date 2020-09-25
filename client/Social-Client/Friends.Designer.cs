namespace Social_Client
{
    partial class Friends
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
            this.addFriendBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.userId = new System.Windows.Forms.TextBox();
            this.friendsList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendsList)).BeginInit();
            this.SuspendLayout();
            // 
            // addFriendBtn
            // 
            this.addFriendBtn.Location = new System.Drawing.Point(305, 36);
            this.addFriendBtn.Name = "addFriendBtn";
            this.addFriendBtn.Size = new System.Drawing.Size(87, 23);
            this.addFriendBtn.TabIndex = 0;
            this.addFriendBtn.Text = "Add Friend";
            this.addFriendBtn.UseVisualStyleBackColor = true;
            this.addFriendBtn.Click += new System.EventHandler(this.AddFriendBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.addFriendBtn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 75);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "User ID:";
            // 
            // userId
            // 
            this.userId.Location = new System.Drawing.Point(12, 39);
            this.userId.Name = "userId";
            this.userId.Size = new System.Drawing.Size(287, 20);
            this.userId.TabIndex = 2;
            // 
            // friendsList
            // 
            this.friendsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.friendsList.Location = new System.Drawing.Point(12, 94);
            this.friendsList.Name = "friendsList";
            this.friendsList.Size = new System.Drawing.Size(407, 344);
            this.friendsList.TabIndex = 2;
            // 
            // Friends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 450);
            this.Controls.Add(this.friendsList);
            this.Controls.Add(this.panel1);
            this.Name = "Friends";
            this.Text = "Friends";
            this.Load += new System.EventHandler(this.Friends_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addFriendBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox userId;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView friendsList;
    }
}