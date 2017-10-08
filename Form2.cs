using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form2 : Form
    {
        DBHandler obj_db;
        Accounts obj_acc;

        public Form2()
        {
            InitializeComponent();
            this.ActiveControl = txtAddDesc;
            
            //Initialize runtime objects...
            obj_db = new DBHandler();
            obj_acc = new Accounts();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAddDesc.Text == "" || txtAddDesc.Text.Length.Equals(0))
            {
                MessageBox.Show("Pleaser enter a Account Description!");
                this.ActiveControl = txtAddDesc;
            }
            else if (txtAddName.Text == "" || txtAddName.Text.Length.Equals(0))
            {
                MessageBox.Show("Pleaser enter a Account Description!");
                this.ActiveControl = txtAddName;
            }
            else if (txtAddPass.Text == "" || txtAddPass.Text.Length.Equals(0))
            {
                MessageBox.Show("Pleaser enter a Account Description!");
                this.ActiveControl = txtAddPass;
            }
            else
            {
                obj_acc.acc_desc = txtAddDesc.Text.ToString();
                obj_acc.acc_name = txtAddName.Text.ToString();
                obj_acc.acc_pass = txtAddPass.Text.ToString();
                obj_db.insert(obj_acc);
                clear_text();
                populate_accounts();
            }
        }

        public void populate_accounts()
        {
            List<Accounts> list = new List<Accounts>();
            list = obj_db.query_all_accounts();

            listView1.Items.Clear();
            for (int i = 0; i < list.Count(); i++)
            {
                ListViewItem lvi = new ListViewItem(list[i].seq_no.ToString());
                lvi.SubItems.Add(list[i].acc_desc.ToString());
                lvi.SubItems.Add(list[i].acc_name.ToString());
                lvi.SubItems.Add(list[i].acc_pass.ToString());
                listView1.Items.Add(lvi);                
            }            
        }

        void clear_text()
        {
            txtAddDesc.Text = "";
            txtAddName.Text = "";
            txtAddPass.Text = "";

            txtAccDescEdit.Text = "";
            txtAccNameEdit.Text = "";
            txtAccPassEdit.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            populate_accounts();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];                         
            if (intselectedindex >= 0)
            {
                txtAccSeqNo.Text = listView1.Items[intselectedindex].Text;                
                txtAccDescEdit.Text = listView1.Items[intselectedindex].SubItems[1].Text;
                txtAccNameEdit.Text = listView1.Items[intselectedindex].SubItems[2].Text;
                txtAccPassEdit.Text = listView1.Items[intselectedindex].SubItems[3].Text;                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                obj_acc.seq_no = int.Parse(txtAccSeqNo.Text.ToString());
                obj_acc.acc_desc = txtAccDescEdit.Text.ToString();
                obj_acc.acc_name = txtAccNameEdit.Text.ToString();
                obj_acc.acc_pass = txtAccPassEdit.Text.ToString();
                obj_db.update(obj_acc);
                MessageBox.Show("Account successfully updated!");
                populate_accounts();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured during update, please ensure there is an account to update in focus.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                obj_db.delete(int.Parse(txtAccSeqNo.Text.ToString()));
                MessageBox.Show("Account successfully deleted!");
                populate_accounts();
                clear_text();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured during delete, please ensure there is an account to delete in focus.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}