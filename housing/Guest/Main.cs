using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace housing
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void hideSubMenu()
        {
            panelInformation.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            showSubMenu(panelInformation);
        }

        private void btnAnnounce_Click(object sender, EventArgs e)
        {
            openChildForm(new Announce());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            openChildForm(new Rules());
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            openChildForm(new Contact());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TenantMain tenant = new TenantMain();
            this.Hide();
            tenant.ShowDialog();
            this.Close();
        }

        private void Forgotbtn_Click(object sender, EventArgs e)
        {
            AdminMain admin = new AdminMain();
            this.Hide();
            admin.ShowDialog();
            this.Close();
        }
    }
}
