using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using AnotherTest.Models;

namespace AnotherTest.Views
{
    public partial class ReadForm : Form
    {

        private SqlConnection sqlcon;
        private byte[] pdffile;
        ConnectDB cn = new ConnectDB();
        private User mainuser;
        public ReadForm(string bookname, string booklink, User user)
        {
            InitializeComponent();
            mainuser = user;
            textBox1.Text = mainuser.name;
            toolStripLabel1.Text = bookname;
            toolStripLabel2.Text = booklink;
            this.axAcroPDF1.src = toolStripLabel2.Text;
        }

        private void Savenote_btn_Click(object sender, EventArgs e)
        {
            sqlcon = cn.getcon();
            try
            {
                sqlcon.Open();
                string savequery = @"Insert into [Notes] ([bookname],[username],[note]) values (@bookname, @username,@note)";
                SqlCommand cmd = new SqlCommand(savequery, sqlcon);
                cmd.Parameters.Add(new SqlParameter("@username", (object)textBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@bookname", (object)toolStripLabel1.Text));
                cmd.Parameters.Add(new SqlParameter("@note", (object)richTextBox1.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Save note sucessfully!");
                this.richTextBox1.Text = "";
            }
            catch
            {
                MessageBox.Show("Error while trying to save the note!");
            }
            sqlcon.Close();
        }

        private void Viewnote_btn_Click(object sender, EventArgs e)
        {
            sqlcon = cn.getcon();
            sqlcon.Open();
            try
            {
                string selectquery = @"Select * from [Notes] where [bookname] like '" + toolStripLabel1.Text + "%'";

                SqlCommand cmd = new SqlCommand(selectquery, sqlcon);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
            }
            catch
            {
                MessageBox.Show("Error while trying to retrieve the note!");
            }
        }

        private void Updatenote_btn_Click(object sender, EventArgs e)
        {
            //sqlcon = cn.getcon();
            //sqlcon.Open();
            //SqlCommand cmd = new SqlCommand(@"Update [MyNote] set [Note] = @Note where [Username] = @Username",sqlcon);
            //cmd.Parameters.AddWithValue("@Username", comboBox1.Text);
            //cmd.Parameters.AddWithValue("@Note", richTextBox1.Text);
            //cmd.ExecuteNonQuery();
            //MessageBox.Show("Update note sucessfully!");
            //sqlcon.Close();
        }

        private void Deletenote_btn_Click(object sender, EventArgs e)
        {
            sqlcon = cn.getcon();
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(@"Delete [Notes] where [note] = @note", sqlcon);
            cmd.Parameters.AddWithValue("@note", richTextBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete note successfully!");
            sqlcon.Close();
            this.richTextBox1.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
