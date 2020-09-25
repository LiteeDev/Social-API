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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(forceExit);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // API Calls.
            userLbl.Text = API.User.username;
            emailLbl.Text = API.User.email;
            
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Convert.ToDouble(API.User.lastLogin)).ToLocalTime();
            lastLoginlbl.Text = Convert.ToString(dtDateTime);

            // Created timestamp;
            System.DateTime dtDateTimeCreated = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTimeCreated = dtDateTimeCreated.AddSeconds(Convert.ToDouble(API.User.created)).ToLocalTime();
            accountCreatedLbl.Text = Convert.ToString(dtDateTimeCreated);
        }

        private void forceExit(object sender, FormClosingEventArgs e)
        {
            // Force Exit once dashboard is closed.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
