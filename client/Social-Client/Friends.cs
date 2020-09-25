using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Social_Client
{
    public partial class Friends : Form
    {
        public Friends()
        {
            InitializeComponent();
        }

        private void AddFriendBtn_Click(object sender, EventArgs e)
        {
            string friendId = userId.Text;

            if (API.AddFriend(friendId))
            {
                // Set user session and start main form;
                MessageBox.Show("Your friends request has been succesfully sent..");
                API.Friends(friendsList);

            }

        }

        private void Friends_Load(object sender, EventArgs e)
        {
            API.Friends(this.friendsList);
        }
    }
}
