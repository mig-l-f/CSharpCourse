namespace UserManager
{
    partial class Form1
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
            this.lvUsers = new System.Windows.Forms.ListView();
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RealName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelUsername = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.tbRealname = new System.Windows.Forms.TextBox();
            this.labelRealname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvUsers
            // 
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Username,
            this.RealName});
            this.lvUsers.Location = new System.Drawing.Point(16, 117);
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(509, 138);
            this.lvUsers.TabIndex = 5;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            // 
            // Username
            // 
            this.Username.Text = "Username";
            this.Username.Width = 75;
            // 
            // RealName
            // 
            this.RealName.Text = "Real Name";
            this.RealName.Width = 430;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(13, 18);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(77, 17);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Username:";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(108, 13);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(132, 22);
            this.tbUsername.TabIndex = 0;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(272, 18);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(73, 17);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(351, 15);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(174, 22);
            this.tbPassword.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(399, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add user";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(399, 77);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(125, 32);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check user";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // tbRealname
            // 
            this.tbRealname.Location = new System.Drawing.Point(108, 57);
            this.tbRealname.Name = "tbRealname";
            this.tbRealname.Size = new System.Drawing.Size(131, 22);
            this.tbRealname.TabIndex = 2;
            // 
            // labelRealname
            // 
            this.labelRealname.AutoSize = true;
            this.labelRealname.Location = new System.Drawing.Point(22, 57);
            this.labelRealname.Name = "labelRealname";
            this.labelRealname.Size = new System.Drawing.Size(80, 17);
            this.labelRealname.TabIndex = 8;
            this.labelRealname.Text = "Real name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 263);
            this.Controls.Add(this.labelRealname);
            this.Controls.Add(this.tbRealname);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.lvUsers);
            this.Name = "Form1";
            this.Text = "User Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader RealName;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox tbRealname;
        private System.Windows.Forms.Label labelRealname;
    }
}

