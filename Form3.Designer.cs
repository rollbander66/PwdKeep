﻿namespace TestForm
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtMasterUser = new System.Windows.Forms.TextBox();
            this.txtMasterPass = new System.Windows.Forms.TextBox();
            this.txtMasterPass2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(128, 134);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtMasterUser
            // 
            this.txtMasterUser.Location = new System.Drawing.Point(123, 37);
            this.txtMasterUser.Name = "txtMasterUser";
            this.txtMasterUser.Size = new System.Drawing.Size(160, 20);
            this.txtMasterUser.TabIndex = 1;
            // 
            // txtMasterPass
            // 
            this.txtMasterPass.Location = new System.Drawing.Point(123, 63);
            this.txtMasterPass.Name = "txtMasterPass";
            this.txtMasterPass.PasswordChar = '*';
            this.txtMasterPass.Size = new System.Drawing.Size(160, 20);
            this.txtMasterPass.TabIndex = 2;
            // 
            // txtMasterPass2
            // 
            this.txtMasterPass2.Location = new System.Drawing.Point(123, 89);
            this.txtMasterPass2.Name = "txtMasterPass2";
            this.txtMasterPass2.PasswordChar = '*';
            this.txtMasterPass2.Size = new System.Drawing.Size(160, 20);
            this.txtMasterPass2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirm Password:";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(339, 183);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMasterPass2);
            this.Controls.Add(this.txtMasterPass);
            this.Controls.Add(this.txtMasterUser);
            this.Controls.Add(this.btnCreate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "PwdKeep - Create Master Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtMasterUser;
        private System.Windows.Forms.TextBox txtMasterPass;
        private System.Windows.Forms.TextBox txtMasterPass2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}