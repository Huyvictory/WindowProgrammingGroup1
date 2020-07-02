using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherTest.Models;

namespace AnotherTest.Views
{
    public partial class Main : Form
    {
        private RoadMap formrm;
        private AddBook formab;
        private SqlConnection sqlcon;
        ConnectDB cn = new ConnectDB();
        private User mainuser;
        private frmLogIn formlg;
        private UpdateInfo formui;
        private AllUser formal;
        private frmPassChange formcp;
        public Main(User user)
        {
            InitializeComponent();
            mainuser = user;
            this.label2.Text = mainuser.name;
            if (mainuser.username != "admin")
            {
                adminToolStripMenuItem.Visible = false;
            }
            else
            {
                adminToolStripMenuItem.Visible = true;
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void alluserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                if (formal is null || formal.IsDisposed)
                {
                    formal = new AllUser(ref mainuser);
                    formal.Show();
                }
                else
                {
                    formal.Select();
                }
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formcp is null || formcp.IsDisposed)
            {
                formcp = new frmPassChange(ref mainuser);
                formcp.Show();
            }
            else
            {
                formcp.Select();
            }
        }

        private void updateProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formui is null || formui.IsDisposed)
            {
                formui = new UpdateInfo(ref mainuser);
                formui.Show();
            }
            else
            {
                formui.Select();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
                sqlcon = cn.getcon();
                sqlcon.Open();
                try
                {
                    string searchquery = @"Select * from [Documents] where [bookname] like '" + txtSearch.Text + "%'";
                    SqlCommand cmd = new SqlCommand(searchquery, sqlcon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.RowTemplate.Height = 120;
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                    da.Dispose();
                }
                catch
                {
                    MessageBox.Show("Error!");
                }
        }

        private void addDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formab is null || formab.IsDisposed)
            {
                formab = new AddBook();
                formab.Show();
            }
            else
            {
                formab.Select();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BookInfo f1 = new BookInfo(mainuser);
            f1.label3.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Byte[] data = new Byte[0];
            data = (Byte[])dataGridView1.CurrentRow.Cells[3].Value;
            MemoryStream mem = new MemoryStream(data);
            f1.pictureBox1.Image = Image.FromStream(mem);
            f1.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            f1.label4.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f1.comboBox1.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f1.label8.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f1.ShowDialog();
        }

        private void roadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formrm is null || formrm.IsDisposed)
            {
                formrm = new RoadMap(mainuser);
                formrm.Show();
            }
            else
            {
                formrm.Select();
            }
        }
    }
}
