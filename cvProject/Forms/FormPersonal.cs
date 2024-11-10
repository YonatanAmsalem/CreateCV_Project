using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cvProject.Forms
{
    public partial class FormPersonal : Form
    {
        PersonalInfo personal = new PersonalInfo();
        public FormPersonal()
        {
            InitializeComponent();
            //polymorphism
            cvComponent cvObj = new PersonalInfo();
            if (!cvObj.checkIfObjectInTheList())
                cvObj.addTocvCompList();
        }
        public void setDataTotb()
        {
            firstName_tb.Text = Program.per.firstNAME;
            lastName_tb.Text = Program.per.LastNAME;
            address_tb.Text = Program.per.ADDRESS;
            id_tb.Text = Program.per.ID;
            Email_tb.Text = Program.per.EMAIL;
            phone_tb.Text = Program.per.PHONE;
            if (Program.per.IMAGEPATH != "")
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(Program.per.IMAGEPATH);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        //load the user input to the members of class PersonalInfo
        private void save_btn_Click(object sender, EventArgs e)
        {
            string firstName = firstName_tb.Text;
            string lastName = lastName_tb.Text;
            string address = address_tb.Text;
            string id = id_tb.Text;
            string email = Email_tb.Text;
            string phone = phone_tb.Text;
            string DateofBirth = dateTimePicker1.Value.ToString("dd-MM-yyyy");

            if (Program.checkValidInputName(firstName) && Program.checkValidInputName(lastName) && Program.checkValidInputNumeric(id) && Program.checkValidInputNumeric(phone)) 
            {
                personal.firstNAME = firstName;
                personal.LastNAME = lastName;
                personal.ADDRESS = address;
                personal.ID = id;
                personal.EMAIL = email;
                personal.dateofBIRTH = DateofBirth;
                personal.PHONE = phone;
                personal.IMAGEPATH = Program.per.IMAGEPATH;
                Program.per = personal;
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }
     
        private void load_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                { 
                    string selectedImagePath = openFileDialog.FileName;
                    pictureBox1.Image = System.Drawing.Image.FromFile(selectedImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                    Program.per.IMAGEPATH = selectedImagePath;
                }
              
            }
        }
    }
}
