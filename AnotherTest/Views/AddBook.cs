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
    public partial class AddBook : Form
    {
        private Document addbook;
        public AddBook()
        {
            InitializeComponent();
            addbook = new Document();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog x = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "JPG;JPEG;JPE;JFIF;PNG| *.jpg; *.jpeg; *.jpe; *.jfif; *.png" })
            {
                if (x.ShowDialog() == DialogResult.OK)
                {
                    addbook.photo = BookController.Converttobinary(x.FileName);
                    pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxImage.Image = Image.FromFile(x.FileName);
                    this.label6.Text = x.FileName;
                }
            }
        }

        private void btAddlink_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog x = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "PDF|*.pdf" })
            {
                if (x.ShowDialog() == DialogResult.OK)
                {
                    label4.Text = x.FileName;
                    addbook.link = x.FileName;
                    this.txtBookname.Text = "" + x.FileName.Substring((x.FileName.LastIndexOf("\\")) + 1);
                    addbook.bookname = this.txtBookname.Text;
                }
            }
        }

        private void btAddbook_Click(object sender, EventArgs e)
        {
            if (this.addbook.link.Length <= 0)
            {
                MessageBox.Show("Need to add book's link.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.txtBookname.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Enter Book Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.comboBox1.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Enter Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (BookController.checkExistBook(this.addbook.link.Trim()) == true)
                {
                    MessageBox.Show("This Book has been add!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Document book = new Document();
            book.link = addbook.link;
            book.bookname = addbook.bookname;
            book.photolink = this.label6.Text;
            book.photo = addbook.photo;
            book.type = comboBox1.Text;




            if (BookController.addBook(book) == false)
            {
                MessageBox.Show("Error in adding a new Book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Book Added");

            this.label4.Text = "";
            addbook.link = "";
            this.txtBookname.Text = "";
            addbook.bookname = "";
            pictureBoxImage.CreateGraphics().Clear(Color.White);
            this.comboBox1.Text = "";
            addbook.type = "";
            this.label6.Text = "...";
        }
    }
}
