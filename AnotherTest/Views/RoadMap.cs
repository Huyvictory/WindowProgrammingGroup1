using AnotherTest.Controllers;
using AnotherTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherTest.Views
{
    public partial class RoadMap : Form
    {
        private User mainuser;
        private SqlConnection sqlcon;
        ConnectDB cn = new ConnectDB();
        public RoadMap(User user)
        {
            mainuser = user;
            InitializeComponent();
            label2.Text = mainuser.username;
        }
        private void btRefresh_Click(object sender, EventArgs e)
        {
            sqlcon = cn.getcon();
            sqlcon.Open();
            try
            {
                string selectquery = @"Select * from [RoadMaps] where [username] like '" + this.label2.Text + "%'";


                SqlCommand cmd = new SqlCommand(selectquery, sqlcon);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 120;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Error while trying to retrieve the RoadMap!");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;
            string book = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();

            if (RoadMapController.DeletefromRM(book) == false)
            {
                MessageBox.Show("Cant delete book.");
            }
            else
            {
                MessageBox.Show("Delete Sucessfully, please refresh the roadmap!!!");
                BindingSource source = new BindingSource();
                source.DataSource = RoadMapController.GetRoadMap();
                this.dataGridView1.DataSource = source;
            }
        }
    }
}
