using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
using UserManager.Model.Users;

namespace UserManager
{
    public partial class Form1 : Form
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public Form1()
        {
            InitializeComponent();
            users.CollectionChanged += new NotifyCollectionChangedEventHandler(this.updateList);
            
        }

        private void updateList(object sender, EventArgs e)
        {
            // TODO: Is there a neater way to do this, where we keep
            // directly in sync with the internal List of items
            // purchased?
            lvUsers.BeginUpdate();
            lvUsers.Items.Clear();
            for (int x = 0; x < users.Count; x++)
            {
                lvUsers.Items.Add(
                    new ListViewItem(
                        new String[] { users[x].Username, users[x].Realname }
                    )
                );
            }

            // This set of statements tries two types of auto-resizing- one
            // based on the width of the column header text, and one based
            // on the longest content row.
            // By testing which results in the widest column (and reverting
            // if that ColumnHeaderAutoResizeStyle is narrower), we can make
            // sure nothing ends up hidden.
            // This would cause visible flickering if not for the BeginUpdate()
            // and EndUpdate() calls surrounding this method.
            lvUsers.AutoResizeColumn(0,
                ColumnHeaderAutoResizeStyle.ColumnContent);
            int width = lvUsers.Columns[0].Width;
            lvUsers.AutoResizeColumn(0,
                ColumnHeaderAutoResizeStyle.HeaderSize);
            if (lvUsers.Columns[0].Width < width)
                lvUsers.AutoResizeColumn(0,
                ColumnHeaderAutoResizeStyle.ColumnContent);

            lvUsers.AutoResizeColumn(1,
                ColumnHeaderAutoResizeStyle.ColumnContent);
            width = lvUsers.Columns[1].Width;
            lvUsers.AutoResizeColumn(1,
                ColumnHeaderAutoResizeStyle.HeaderSize);
            if (lvUsers.Columns[1].Width < width)
                lvUsers.AutoResizeColumn(1,
                ColumnHeaderAutoResizeStyle.ColumnContent);

            lvUsers.EndUpdate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            byte[] dataToHash = Encoding.UTF8.GetBytes(tbPassword.Text);
            byte[] secretKey = Encoding.UTF8.GetBytes(tbUsername.Text);
            users.Add(new User(tbUsername.Text, ComputeHash(dataToHash, secretKey), tbRealname.Text));
        }

        public byte[] ComputeHash(byte[] dataToHash, byte[] secretKey)
        {
            using (var hashAlgorithm = new HMACSHA512(secretKey))
            {
                using (var bufferStream = new MemoryStream(dataToHash))
                {
                    return hashAlgorithm.ComputeHash(bufferStream);
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            byte[] dataToHash = Encoding.UTF8.GetBytes(tbPassword.Text);
            byte[] secretKey = Encoding.UTF8.GetBytes(tbUsername.Text);

            // We also need to check the username is the same!
            //if (ComputeHash(dataToHash, secretKey).SequenceEqual(
            //    users[Convert.ToInt32(lvUsers.SelectedIndices[0])].Password))
            //{
            //    MessageBox.Show(this, "Passwords match");
            //}
            //else
            //{
            //    MessageBox.Show(this, "Passwords DO NOT match");
            //}

        }
    }
}
