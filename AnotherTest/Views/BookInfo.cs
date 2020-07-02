using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherTest.Models;
using AnotherTest;
using AnotherTest.Controllers;
using System.Data.SqlClient;

namespace AnotherTest.Views
{

    public partial class BookInfo : Form
    {
        private User mainuser;
        private int rmcount;

        public BookInfo(User user)
        {
            mainuser = user;
            rmcount = RoadMapController.GetRoadMap().Count();

            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private byte[] image;
        ConnectDB cn = new ConnectDB();
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            ReadForm form2 = new ReadForm(label3.Text,label8.Text,mainuser);
            form2.ShowDialog();
            
        }

        private void btAddRM_Click(object sender, EventArgs e)
        {
            sqlcon = cn.getcon();
                try
                {
                    sqlcon.Open();
                    image = BookController.Converttobinary(this.label4.Text);
                    string savetoDBquery = @"Insert into [RoadMaps] ([rmid],[link],[username],[bookname],[photolink],[photo],[type])
                                    values (@rmid,@link,@username,@bookname,@photolink,@photo,@type)";
                    SqlCommand cmd = new SqlCommand(savetoDBquery, sqlcon);
                    cmd.Parameters.Add(new SqlParameter("@rmid", (object)rmcount));
                    cmd.Parameters.Add(new SqlParameter("@username", (object)mainuser.username));
                    cmd.Parameters.Add(new SqlParameter("@link", (object)label8.Text));
                    cmd.Parameters.Add(new SqlParameter("@bookname", (object)label3.Text));
                    cmd.Parameters.Add(new SqlParameter("@photolink", (object)label4.Text));
                    cmd.Parameters.Add(new SqlParameter("@photo", (object)image));
                    cmd.Parameters.Add(new SqlParameter("@type", (object)comboBox1.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully add to RoadMap!");
                    rmcount += 1;
                }
                catch
                {
                    MessageBox.Show("Error!");
                }
            sqlcon.Close();
        }
      
    }
}
