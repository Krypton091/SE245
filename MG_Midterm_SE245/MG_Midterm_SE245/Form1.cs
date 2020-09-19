using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MG_Midterm_SE245
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        public Form1(int intPerson_ID)
        {
            InitializeComponent();

            btnSubmit.Visible = false;

            //Gather info about this one person and store it in a datareader
            PersonV2 temp = new PersonV2();
            SqlDataReader dr = temp.FindOnePerson(intPerson_ID);

            //Use that info to fill out the form
            //Loop thru the records stored in the reader 1 record at a time
            // Note that since this is based on one person's ID, then we
            //  should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them
                // into the appropriate text fields
                txtfName.Text = dr["FirstName"].ToString();
                txtmName.Text = dr["MiddleName"].ToString();
                txtlName.Text = dr["LastName"].ToString();
                txtStreet.Text = dr["Street1"].ToString();
                txtStreet2.Text = dr["Street2"].ToString();
                txtcity.Text = dr["City"].ToString();
                txtstate.Text = dr["State"].ToString();
                txtzipcode.Text = dr["Zipcode"].ToString();
                txtphone.Text = dr["Phone"].ToString();
                txtemail.Text = dr["Email"].ToString();
                txtcellphone.Text = dr["Cellphone"].ToString();
                txtinstaURL.Text = dr["Instagram"].ToString();
                lblPerson_ID.Text = dr["Person_ID"].ToString();


                //We added this one to store the ID in a new label
                lblPerson_ID.Text = dr["Person_ID"].ToString();
            }
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
            PersonV2 temp = new PersonV2();
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
            temp.Cellphone = txtcellphone.Text;
            temp.InstagramURL = txtinstaURL.Text;

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = "New person" + " \"" + temp.FName + " " + temp.LName + "\" has been succesfully added";
                lblFeedback.Text = temp.AddARecord();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PersonV2 temp = new PersonV2();

            //Getting the strings from the form and setting them in object
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
            temp.Cellphone = txtcellphone.Text;
            temp.InstagramURL = txtinstaURL.Text;
            temp.Person_ID = Convert.ToInt32(lblPerson_ID.Text);

            if (!temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.UpdateARecord();   //if no errors weh setting values, then perform the insertion into db
            }
            else
            {
                lblFeedback.Text = temp.Feedback;       //else...dispay the error msg
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 intPerson_ID = Convert.ToInt32(lblPerson_ID.Text);  //Get the ID from the Label

            //Create a EBook so we can use the delete method
            PersonV2 temp = new PersonV2();

            //Use the EBook ID and pass it to the delete function
            // and get the number of records deleted
            lblFeedback.Text = temp.DeleteOnePerson(intPerson_ID);

        }
    }
}
