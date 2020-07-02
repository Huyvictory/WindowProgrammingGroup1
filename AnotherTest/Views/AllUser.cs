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
    public partial class AllUser : Form
    {
        List<User> listuser;
        public AllUser(ref User users )
        {
            InitializeComponent();
            listuser = UserController.GetallUsers();
            this.cID.DataPropertyName = nameof(User.id);
            this.cUsername.DataPropertyName = nameof(User.username);
            this.cPassword.DataPropertyName = nameof(User.password);
            this.cName.DataPropertyName = nameof(User.name);
            this.cBirthday.DataPropertyName = nameof(User.birthday);
            this.cPhone.DataPropertyName = nameof(User.phone);
            this.cEmail.DataPropertyName = nameof(User.email);

            BindingSource source = new BindingSource();
            source.DataSource = UserController.GetallUsers();
            this.dataUsers.DataSource = source;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (this.dataUsers.SelectedRows.Count <= 0)
                return;
            string username = this.dataUsers.SelectedRows[0].Cells[1].Value.ToString().Trim();
            if(username == "admin")
            {
                MessageBox.Show("Can not delete admin account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (UserController.DeleteUser(username) == false)
            {
                MessageBox.Show("Cant delete user.");
            }
            else
            {
                BindingSource source = new BindingSource();
                source.DataSource = UserController.GetallUsers();
                this.dataUsers.DataSource = source;
            }
        }
    }
}
