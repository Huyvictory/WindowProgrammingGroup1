using AnotherTest.Controllers;
using AnotherTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherTest.Views
{
    public partial class frmPassChange : Form
    {
        private User mainuser;
        public frmPassChange(ref User user)
        {
            InitializeComponent();
            mainuser = user;
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            if(this.mainuser.password != txtPCpass.Text)
            {
                MessageBox.Show("Wrong Password.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                if(this.txtNewpass.Text != this.txtConfirm.Text)
                {
                    MessageBox.Show("Password does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    UserController.Changepass(mainuser, txtNewpass.Text);                    
                    this.txtConfirm.Clear();
                    this.txtNewpass.Clear();
                    this.txtPCpass.Clear();
                    MessageBox.Show("Password changed.");
                    this.Close();
                }
            }
        }
    }
}
