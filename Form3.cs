using System;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form3 : Form
    {
        DBHandler obj_db;

        public Form3()
        {
            InitializeComponent();
            obj_db = new DBHandler();
            this.ActiveControl = txtMasterUser;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (passwords_match())
            {
                obj_db.insert_master_acc(txtMasterUser.Text, txtMasterPass.Text);
                MessageBox.Show("Master Account created!");
                Form1 form1 = new Form1();
                form1.Tag = this;
                form1.Show(this);
                Hide();
            }
            else
            {
                MessageBox.Show("Passwords do not match!");
                txtMasterPass.Text = "";
                txtMasterPass2.Text = "";
                this.ActiveControl = txtMasterPass;
            }
        }

        private bool passwords_match()
        {
            if (txtMasterPass.Text != txtMasterPass2.Text) {
                return false;
            }
            else {
                return true;
            }            
        }
    }
}
