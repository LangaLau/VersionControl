using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();

            lblFullName.Text = Resource.FullName;
            btnAdd.Text = Resource.Add;
            btnToFile.Text = Resource.WriteToFile;
            lblList.Text = Resource.List;
            btnDelete.Text = Resource.Delete;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var n = new User()
            {
                FullName = txtFullName.Text
            };
            users.Add(n);
        }

        private void btnToFile_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                foreach (var u in users)
                    sw.WriteLine(string.Format(
                        "{0},{1}",
                        u.ID,
                        u.FullName));

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var del = listBox1.SelectedItem;
            if (del!=null)
            users.Remove((User)del);
        }
    }
}
