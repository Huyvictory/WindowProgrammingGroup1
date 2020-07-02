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

    public partial class UpdateInfo : Form
    {
        private User mainuser;
        public UpdateInfo(ref User user)
        {
            mainuser = user;
            InitializeComponent();
            txtEmail.Text = user.email;
            txtName.Text = user.name;
            txtPhone.Text = user.phone;
            dateTimeBirthday.Value = user.birthday.Value;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            mainuser.name = txtName.Text;
            mainuser.email = txtEmail.Text;
            mainuser.phone = txtPhone.Text;
            mainuser.birthday = dateTimeBirthday.Value;

            if (dateTimeBirthday.Value >= DateTime.Now)
            {
                MessageBox.Show("Birthday invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                UserController.updateUser(mainuser);
                MessageBox.Show("User updated.");
            }

        }
    }
}
