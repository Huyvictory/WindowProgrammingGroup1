using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherTest.Controllers;
using AnotherTest.Models;

namespace AnotherTest.Views
{
    public partial class frmRegistration : Form
    {
        private List<User> listuser;
        public frmRegistration()
        {
            InitializeComponent();
            listuser = UserController.GetallUsers();
        }

        private void btRegist_Click_1(object sender, EventArgs e)
        {
            if (this.txtUsername.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Enter Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.txtPass.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.txtName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Enter Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.txtConfirm.Text != this.txtPass.Text)
            {
                MessageBox.Show("Wrong password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (UserController.checkExistUsername(this.txtUsername.Text.Trim()) == true)
                {
                    MessageBox.Show("This username is already exist!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            User user = new User();
            user.username = this.txtUsername.Text.Trim();
            user.password = this.txtPass.Text.Trim();
            user.name = this.txtName.Text.Trim();
            user.phone = this.txtPhone.Text.Trim();
            user.birthday = this.dateTimeBirthday.Value;
            user.email = this.txtEmail.Text.Trim();


            if (UserController.addUser(user) == false)
            {
                MessageBox.Show("Error in adding a new user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("User Registed.");




            this.txtUsername.Text = null;
            this.txtPass.Text = null;
            this.txtConfirm.Text = null;
            this.txtName.Text = null;
            this.dateTimeBirthday.Value = DateTime.Now;
            this.txtPhone.Text = null;
            this.txtEmail.Text = null;
        }

        private void btReset_Click_1(object sender, EventArgs e)
        {
            this.txtUsername.Text = null;
            this.txtPass.Text = null;
            this.txtName.Text = null;
            this.dateTimeBirthday.Value = DateTime.Now;
            this.txtPhone.Text = null;
            this.txtEmail.Text = null;
        }
    }
}
