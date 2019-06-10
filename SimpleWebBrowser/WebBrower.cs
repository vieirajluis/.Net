using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appWebBrowser
{
    public partial class frmWebBrower : Form
    {
        public frmWebBrower()
        {
            InitializeComponent();

        }

        private void CreateBrowser()
        {
           
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Navigate("http://www.google.com");
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack(); 
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("http://www.google.com");
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(txtURL.Text);
        }

        private void frmWebBrower_Load(object sender, EventArgs e)
        {
            CreateBrowser();
        }
    }
}
