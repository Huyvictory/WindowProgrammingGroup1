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

namespace AnotherTest.Views
{
    public partial class frmLogIn : Form
    {
        private List<User> listuser;
        private frmRegistration reg;
        private Main ma;
        public frmLogIn()
        {
            InitializeComponent();
            listuser = UserController.GetallUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (reg is null || reg.IsDisposed)
            {
                reg = new frmRegistration();
                reg.Show();
            }
            else
            {
                reg.Select();
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            User temp = new User();
            temp = UserController.getExistUsername(this.txtUUsername.Text.Trim()); // get User
            if (temp != null)
            {
                if (this.txtUPass.Text == temp.password)
                {
                    if (ma is null || ma.IsDisposed)
                    {
                        ma = new Main(temp);
                        this.txtUUsername.Clear();
                        this.txtUPass.Clear();
                        ma.Show();
                    }
                    else
                    {
                        ma.Select();
                    }
                }
                else
                {
                    MessageBox.Show("Password doesn't correct!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("User don't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }
    }
}
