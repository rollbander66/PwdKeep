using System;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {

        DBHandler db_obj;
        private int master_row_count;

        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = txtUsername;

            //Initialize runtime objects...
            db_obj = new DBHandler();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try {
                master_row_count = db_obj.count_master_rows();
            }            
            catch (Exception) {
                master_row_count = 0;
            }

            if (master_row_count == 0)
            {
                MessageBox.Show("First time login detected, please create a master account.");
                Form3 form3 = new Form3();
                form3.Tag = this;
                form3.Show(this);
                Hide();
            }
            else
            {
                db_obj.query_master_acc(txtUsername.Text.ToString(), txtPass.Text.ToString());
                if (db_obj.loginSuccess == true)
                {
                    MessageBox.Show("Login Successful");
                    Form2 form2 = new Form2();
                    form2.Tag = this;
                    form2.Show(this);
                    Hide();
                }
                else
                {
                    MessageBox.Show("Login Unsuccessful");
                    txtUsername.Text = "";
                    txtPass.Text = "";
                    txtUsername.Focus();
                }
            }                      
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO:
            //Implement temporary password email to allow user to login and change master password.
        }
    }
}
