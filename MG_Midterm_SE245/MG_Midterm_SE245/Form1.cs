using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG_Midterm_SE245
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person temp = new Person();
            temp.FName = txtfName.Text;
            temp.MName = txtmName.Text;
            temp.LName = txtlName.Text;
            temp.Street1 = txtStreet.Text;
            temp.Street2 = txtStreet2.Text;
            temp.City = txtcity.Text;
            temp.State = txtstate.Text;
            temp.Zipcode = txtzipcode.Text;
            temp.Phone = txtphone.Text;
            temp.Email = txtemail.Text;

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = "New person" + " \"" + temp.FName + " " + temp.LName + "\" has been succesfully added";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
