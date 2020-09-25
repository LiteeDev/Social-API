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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;

            if(API.Login(username, password))
            {
                // Set user session and start main form;
                MessageBox.Show("Welcome Back, " + API.User.username + "!");
                this.Hide();
                var Dashboard = new Dashboard();
                Dashboard.ShowDialog();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            passwordTxt.PasswordChar = '*';
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog();
        }
    }
}
